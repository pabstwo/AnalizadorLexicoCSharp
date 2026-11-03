using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using AnalizadorLexicoCSharp.Modelos;

namespace AnalizadorLexicoCSharp.Analisis
{
    public class DiccionarioLexico
    {
        private static readonly DiccionarioLexico instancia =
            new DiccionarioLexico();

        private readonly string rutaArchivo;
        private readonly JsonSerializerOptions opcionesJson;

        private List<EntradaDiccionario> entradas;

        public static DiccionarioLexico Instancia
        {
            get { return instancia; }
        }

        public event Action? DiccionarioCambiado;

        private DiccionarioLexico()
        {
            string carpetaDatos = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "AnalizadorLexicoCSharp"
            );

            Directory.CreateDirectory(carpetaDatos);

            rutaArchivo = Path.Combine(
                carpetaDatos,
                "diccionario_lexico.json"
            );

            opcionesJson = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            opcionesJson.Converters.Add(
                new JsonStringEnumConverter()
            );

            entradas = new List<EntradaDiccionario>();

            Cargar();
        }

        public List<EntradaDiccionario> ObtenerEntradas()
        {
            return entradas
                .OrderBy(entrada => entrada.Lexema)
                .Select(CopiarEntrada)
                .ToList();
        }

        public EntradaDiccionario? Buscar(string lexema)
        {
            EntradaDiccionario? entrada = entradas.FirstOrDefault(
                elemento => elemento.Lexema.Equals(
                    lexema.Trim(),
                    StringComparison.OrdinalIgnoreCase)
            );

            if (entrada == null)
            {
                return null;
            }

            return CopiarEntrada(entrada);
        }

        public bool EsPalabraReservada(string lexema)
        {
            EntradaDiccionario? entrada = entradas.FirstOrDefault(
                elemento =>
                    elemento.Lexema.Equals(
                        lexema,
                        StringComparison.Ordinal) &&
                    elemento.Tipo == TipoToken.PalabraReservada
            );

            return entrada != null;
        }

        public bool EsTipoDato(string lexema)
        {
            EntradaDiccionario? entrada = entradas.FirstOrDefault(
                elemento =>
                    elemento.Lexema.Equals(
                        lexema,
                        StringComparison.Ordinal) &&
                    elemento.EsTipoDato
            );

            return entrada != null;
        }

        public bool Agregar(
            EntradaDiccionario nuevaEntrada,
            out string mensaje)
        {
            if (!ValidarEntrada(nuevaEntrada, out mensaje))
            {
                return false;
            }

            string lexemaLimpio = nuevaEntrada.Lexema.Trim();

            if (ExisteLexema(lexemaLimpio))
            {
                mensaje =
                    "El lexema ya se encuentra registrado en el diccionario.";

                return false;
            }

            nuevaEntrada.Lexema = lexemaLimpio;
            nuevaEntrada.Descripcion =
                nuevaEntrada.Descripcion.Trim();

            entradas.Add(CopiarEntrada(nuevaEntrada));

            Guardar();
            NotificarCambio();

            mensaje = "Entrada agregada correctamente.";
            return true;
        }

        public bool Editar(
            string lexemaOriginal,
            EntradaDiccionario entradaActualizada,
            out string mensaje)
        {
            if (!ValidarEntrada(entradaActualizada, out mensaje))
            {
                return false;
            }

            EntradaDiccionario? entradaExistente =
                entradas.FirstOrDefault(
                    elemento => elemento.Lexema.Equals(
                        lexemaOriginal,
                        StringComparison.OrdinalIgnoreCase)
                );

            if (entradaExistente == null)
            {
                mensaje =
                    "No se encontró la entrada que desea editar.";

                return false;
            }

            string nuevoLexema =
                entradaActualizada.Lexema.Trim();

            bool duplicado = entradas.Any(
                elemento =>
                    !ReferenceEquals(elemento, entradaExistente) &&
                    elemento.Lexema.Equals(
                        nuevoLexema,
                        StringComparison.OrdinalIgnoreCase)
            );

            if (duplicado)
            {
                mensaje =
                    "No se puede guardar porque el lexema ya existe.";

                return false;
            }

            entradaExistente.Lexema = nuevoLexema;
            entradaExistente.Tipo = entradaActualizada.Tipo;
            entradaExistente.Descripcion =
                entradaActualizada.Descripcion.Trim();
            entradaExistente.EsTipoDato =
                entradaActualizada.EsTipoDato;

            Guardar();
            NotificarCambio();

            mensaje = "Entrada actualizada correctamente.";
            return true;
        }

        public bool Eliminar(
            string lexema,
            out string mensaje)
        {
            EntradaDiccionario? entrada = entradas.FirstOrDefault(
                elemento => elemento.Lexema.Equals(
                    lexema.Trim(),
                    StringComparison.OrdinalIgnoreCase)
            );

            if (entrada == null)
            {
                mensaje =
                    "No se encontró la entrada que desea eliminar.";

                return false;
            }

            entradas.Remove(entrada);

            Guardar();
            NotificarCambio();

            mensaje = "Entrada eliminada correctamente.";
            return true;
        }

        private bool ExisteLexema(string lexema)
        {
            return entradas.Any(
                elemento => elemento.Lexema.Equals(
                    lexema,
                    StringComparison.OrdinalIgnoreCase)
            );
        }

        private bool ValidarEntrada(
            EntradaDiccionario entrada,
            out string mensaje)
        {
            if (entrada == null)
            {
                mensaje = "La entrada del diccionario no es válida.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(entrada.Lexema))
            {
                mensaje = "Debe ingresar un lexema.";
                return false;
            }

            if (entrada.Lexema.Any(char.IsWhiteSpace))
            {
                mensaje =
                    "El lexema no puede contener espacios en blanco.";

                return false;
            }

            mensaje = string.Empty;
            return true;
        }

        private void Cargar()
        {
            if (!File.Exists(rutaArchivo))
            {
                entradas = CrearEntradasIniciales();
                Guardar();
                return;
            }

            try
            {
                string contenido =
                    File.ReadAllText(rutaArchivo);

                List<EntradaDiccionario>? datos =
                    JsonSerializer.Deserialize<
                        List<EntradaDiccionario>>(
                            contenido,
                            opcionesJson
                        );

                entradas = datos ??
                    new List<EntradaDiccionario>();

                EliminarDuplicados();

                if (entradas.Count == 0)
                {
                    entradas = CrearEntradasIniciales();
                    Guardar();
                }
            }
            catch
            {
                entradas = CrearEntradasIniciales();
                Guardar();
            }
        }

        private void Guardar()
        {
            string contenido =
                JsonSerializer.Serialize(
                    entradas
                        .OrderBy(entrada => entrada.Lexema)
                        .ToList(),
                    opcionesJson
                );

            File.WriteAllText(
                rutaArchivo,
                contenido
            );
        }

        private void EliminarDuplicados()
        {
            entradas = entradas
                .Where(entrada =>
                    entrada != null &&
                    !string.IsNullOrWhiteSpace(
                        entrada.Lexema))
                .GroupBy(
                    entrada => entrada.Lexema.Trim(),
                    StringComparer.OrdinalIgnoreCase)
                .Select(grupo => grupo.First())
                .ToList();
        }

        private void NotificarCambio()
        {
            DiccionarioCambiado?.Invoke();
        }

        private EntradaDiccionario CopiarEntrada(
            EntradaDiccionario entrada)
        {
            return new EntradaDiccionario(
                entrada.Lexema,
                entrada.Tipo,
                entrada.Descripcion,
                entrada.EsTipoDato
            );
        }

        private List<EntradaDiccionario>
            CrearEntradasIniciales()
        {
            return new List<EntradaDiccionario>
            {
                CrearReservada(
                    "if",
                    "Estructura condicional"),

                CrearReservada(
                    "else",
                    "Alternativa de una condición"),

                CrearReservada(
                    "while",
                    "Ciclo mientras"),

                CrearReservada(
                    "for",
                    "Ciclo controlado"),

                CrearReservada(
                    "do",
                    "Ciclo hacer mientras"),

                CrearReservada(
                    "switch",
                    "Estructura de selección"),

                CrearReservada(
                    "case",
                    "Caso de una selección"),

                CrearReservada(
                    "default",
                    "Caso predeterminado"),

                CrearReservada(
                    "break",
                    "Finaliza una estructura"),

                CrearReservada(
                    "continue",
                    "Continúa la siguiente iteración"),

                CrearReservada(
                    "return",
                    "Devuelve un resultado"),

                CrearReservada(
                    "int",
                    "Tipo de dato entero",
                    true),

                CrearReservada(
                    "float",
                    "Tipo de dato real de precisión simple",
                    true),

                CrearReservada(
                    "double",
                    "Tipo de dato real de precisión doble",
                    true),

                CrearReservada(
                    "char",
                    "Tipo de dato carácter",
                    true),

                CrearReservada(
                    "bool",
                    "Tipo de dato lógico",
                    true),

                CrearReservada(
                    "string",
                    "Tipo de dato de texto",
                    true),

                CrearReservada(
                    "void",
                    "Ausencia de valor"),

                CrearReservada(
                    "true",
                    "Valor lógico verdadero"),

                CrearReservada(
                    "false",
                    "Valor lógico falso"),

                CrearReservada(
                    "class",
                    "Declaración de una clase"),

                CrearReservada(
                    "static",
                    "Miembro estático"),

                CrearReservada(
                    "public",
                    "Modificador de acceso público"),

                CrearReservada(
                    "private",
                    "Modificador de acceso privado"),

                CrearReservada(
                    "protected",
                    "Modificador de acceso protegido"),

                CrearReservada(
                    "new",
                    "Creación de una instancia"),

                CrearReservada(
                    "using",
                    "Importación de un espacio de nombres"),

                CrearReservada(
                    "namespace",
                    "Declaración de un espacio de nombres")
            };
        }

        private EntradaDiccionario CrearReservada(
            string lexema,
            string descripcion,
            bool esTipoDato = false)
        {
            return new EntradaDiccionario(
                lexema,
                TipoToken.PalabraReservada,
                descripcion,
                esTipoDato
            );
        }
    }
}