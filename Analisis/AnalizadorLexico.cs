using System.Collections.Generic;
using AnalizadorLexicoCSharp.Modelos;
using System.Text;

namespace AnalizadorLexicoCSharp.Analisis
{
    public class AnalizadorLexico
    {
        private readonly TablaSimbolos tablaSimbolos;

        private string codigoFuente;
        private int posicion;
        private int linea;
        private int columna;
        private int numeroToken;
        private string tipoDatoPendiente = "No determinado";

        private ResultadoAnalisis resultado;

        private readonly HashSet<string> palabrasReservadas =
            new HashSet<string>
            {
                "if", "else", "while", "for", "do",
                "switch", "case", "default",
                "break", "continue", "return",
                "int", "float", "double", "char",
                "bool", "string", "void",
                "true", "false",
                "class", "static",
                "public", "private", "protected",
                "new", "using", "namespace"
            };
       
        public AnalizadorLexico()
        {
            tablaSimbolos = new TablaSimbolos();
            codigoFuente = string.Empty;
            resultado = new ResultadoAnalisis();
        }

        public ResultadoAnalisis Analizar(string codigo)
        {
            PrepararAnalisis(codigo);

            while (!FinDelCodigo())
            {

                char actual = CaracterActual();

                if (char.IsWhiteSpace(actual))
                {
                    Avanzar();
                }
                else if (char.IsLetter(actual) || actual == '_')
                {
                    ReconocerIdentificadorOPalabraReservada();
                }
                else if (char.IsDigit(actual))
                {
                 ReconocerNumero();
                }
                else if (actual == '"')
                {
                    ReconocerCadena();
                }
                else if (actual == '\'')
                {
                    ReconocerCaracter();
                }
                else if (actual == '/' && CaracterSiguiente() == '/')
                {
                    ReconocerComentarioLinea();
                }
                else if (actual == '/' && CaracterSiguiente() == '*')
                {
                    ReconocerComentarioBloque();
                }
                else if ("(){}[];,.".Contains(actual))
                {
                    ReconocerDelimitador();
                }
                else if ("+-*/%<>=!&|".Contains(actual))
                {
                    ReconocerOperador();
                }
                else
                {
                    RegistrarCaracterDesconocido();
                }
            }

            resultado.Tokens.Add(new Token(
    numeroToken,
    "EOF",
    TipoToken.FinArchivo,
    linea,
    columna
));

            numeroToken++;
            resultado.Simbolos = tablaSimbolos.ObtenerSimbolos();

            return resultado;
        }

        private void PrepararAnalisis(string codigo)
        {

            codigoFuente = codigo ?? string.Empty;

            posicion = 0;
            linea = 1;
            columna = 1;
            numeroToken = 1;
            tipoDatoPendiente = "No determinado";

            resultado = new ResultadoAnalisis();
            tablaSimbolos.Limpiar();
        }

        private bool FinDelCodigo()
        {
            return posicion >= codigoFuente.Length;
        }

        private char CaracterActual()
        {
            if (FinDelCodigo())
            {
                return '\0';
            }

            return codigoFuente[posicion];
        }

        private char CaracterSiguiente()
        {
            if (posicion + 1 >= codigoFuente.Length)
            {
                return '\0';
            }

            return codigoFuente[posicion + 1];
        }
        private bool EsTipoDato(string texto)
        {
            return texto == "int" ||
                   texto == "float" ||
                   texto == "double" ||
                   texto == "char" ||
                   texto == "bool" ||
                   texto == "string";
        }
        private void ReconocerIdentificadorOPalabraReservada()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();

            while (!FinDelCodigo() &&
                   (char.IsLetterOrDigit(CaracterActual()) ||
                    CaracterActual() == '_'))
            {
                lexema.Append(CaracterActual());
                Avanzar();
            }

            string texto = lexema.ToString();
            TipoToken tipo;

            if (palabrasReservadas.Contains(texto))
            {
                tipo = TipoToken.PalabraReservada;
            }
            else
            {
                tipo = TipoToken.Identificador;
            }

          
            if (tipo == TipoToken.PalabraReservada &&
                EsTipoDato(texto))
            {
                tipoDatoPendiente = texto;
            }

            Token token = new Token(
                numeroToken,
                texto,
                tipo,
                lineaInicio,
                columnaInicio
            );

            resultado.Tokens.Add(token);
            numeroToken++;

            
            if (tipo == TipoToken.Identificador)
            {
                tablaSimbolos.AgregarOActualizar(
                    texto,
                    lineaInicio,
                    columnaInicio,
                    tipoDatoPendiente
                );

                tipoDatoPendiente = "No determinado";
            }
        }
        private void ReconocerNumero()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();

            int cantidadPuntos = 0;
            bool contieneLetras = false;

            while (!FinDelCodigo() &&
                   (char.IsLetterOrDigit(CaracterActual()) ||
                    CaracterActual() == '_' ||
                    CaracterActual() == '.'))
            {
                if (CaracterActual() == '.')
                {
                    cantidadPuntos++;
                }

                if (char.IsLetter(CaracterActual()) ||
                    CaracterActual() == '_')
                {
                    contieneLetras = true;
                }

                lexema.Append(CaracterActual());
                Avanzar();
            }

            string texto = lexema.ToString();

           
            if (contieneLetras)
            {
                RegistrarError(
                    "E02",
                    texto,
                    lineaInicio,
                    columnaInicio,
                    "Un identificador no puede comenzar con un número."
                );

                return;
            }

           
            if (cantidadPuntos > 1)
            {
                RegistrarError(
                    "E04",
                    texto,
                    lineaInicio,
                    columnaInicio,
                    "Número mal formado: contiene más de un punto decimal."
                );

                return;
            }

            
            if (cantidadPuntos == 1 && texto.EndsWith("."))
            {
                RegistrarError(
                    "E03",
                    texto,
                    lineaInicio,
                    columnaInicio,
                    "Número real incompleto: faltan dígitos después del punto."
                );

                return;
            }

            TipoToken tipo;

            if (cantidadPuntos == 1)
            {
                tipo = TipoToken.NumeroReal;
            }
            else
            {
                tipo = TipoToken.NumeroEntero;
            }

            Token token = new Token(
                numeroToken,
                texto,
                tipo,
                lineaInicio,
                columnaInicio
            );

            resultado.Tokens.Add(token);
            numeroToken++;
        }
        private void ReconocerCadena()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();
            bool cerrada = false;
            bool escapeInvalido = false;
            string escapeIncorrecto = "";

            lexema.Append(CaracterActual());
            Avanzar();

            while (!FinDelCodigo() && CaracterActual() != '\n')
            {
                if (CaracterActual() == '\\')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    if (!FinDelCodigo() && CaracterActual() != '\n')
                    {
                        char escapado = CaracterActual();

                        if (!EsEscapeValido(escapado) && !escapeInvalido)
                        {
                            escapeInvalido = true;
                            escapeIncorrecto = "\\" + escapado;
                        }

                        lexema.Append(escapado);
                        Avanzar();
                    }
                }
                else if (CaracterActual() == '"')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    cerrada = true;
                    break;
                }
                else
                {
                    lexema.Append(CaracterActual());
                    Avanzar();
                }
            }

            if (cerrada && !escapeInvalido)
            {
                Token token = new Token(
                    numeroToken,
                    lexema.ToString(),
                    TipoToken.Cadena,
                    lineaInicio,
                    columnaInicio
                );

                resultado.Tokens.Add(token);
                numeroToken++;
            }
            else if (!cerrada)
            {
                RegistrarError(
                    "E05",
                    lexema.ToString(),
                    lineaInicio,
                    columnaInicio,
                    "Cadena sin comilla de cierre."
                );
            }
            else
            {
                RegistrarError(
                    "E08",
                    escapeIncorrecto,
                    lineaInicio,
                    columnaInicio,
                    "Secuencia de escape no permitida."
                );
            }
        }
        private void ReconocerCaracter()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();
            bool cerrado = false;
            bool escapeInvalido = false;
            string escapeIncorrecto = "";

            lexema.Append(CaracterActual());
            Avanzar();

            while (!FinDelCodigo() && CaracterActual() != '\n')
            {
                if (CaracterActual() == '\\')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    if (!FinDelCodigo() && CaracterActual() != '\n')
                    {
                        char escapado = CaracterActual();

                        if (!EsEscapeValido(escapado) && !escapeInvalido)
                        {
                            escapeInvalido = true;
                            escapeIncorrecto = "\\" + escapado;
                        }

                        lexema.Append(escapado);
                        Avanzar();
                    }
                }
                else if (CaracterActual() == '\'')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    cerrado = true;
                    break;
                }
                else
                {
                    lexema.Append(CaracterActual());
                    Avanzar();
                }
            }
            if (cerrado)
            {
                string texto = lexema.ToString();

                bool contenidoValido =
                    texto.Length == 3 ||
                    (texto.Length == 4 && texto[1] == '\\');

                if (escapeInvalido)
                {
                    RegistrarError(
                        "E08",
                        escapeIncorrecto,
                        lineaInicio,
                        columnaInicio,
                        "Secuencia de escape no permitida."
                    );
                }
                else if (contenidoValido)
                {
                    Token token = new Token(
                        numeroToken,
                        texto,
                        TipoToken.Caracter,
                        lineaInicio,
                        columnaInicio
                    );

                    resultado.Tokens.Add(token);
                    numeroToken++;
                }
                else
                {
                    RegistrarError(
                        "E06",
                        texto,
                        lineaInicio,
                        columnaInicio,
                        "El literal de carácter debe contener un solo carácter."
                    );
                }
            }
            else
            {
                RegistrarError(
                    "E06",
                    lexema.ToString(),
                    lineaInicio,
                    columnaInicio,
                    "Literal de carácter sin comilla de cierre."
                );
            }

        }
        private void ReconocerDelimitador()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            string lexema = CaracterActual().ToString();
            Avanzar();

            Token token = new Token(
                numeroToken,
                lexema,
                TipoToken.Delimitador,
                lineaInicio,
                columnaInicio
            );

            resultado.Tokens.Add(token);
            numeroToken++;
        }
        private void ReconocerOperador()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            string lexema = CaracterActual().ToString();
            Avanzar();

            if (!FinDelCodigo())
            {
                string posibleOperador =
                    lexema + CaracterActual();

                string[] operadoresDobles =
                {
            "++", "--",
            "+=", "-=", "*=", "/=", "%=",
            "==", "!=", "<=", ">=",
            "&&", "||"
        };

                if (operadoresDobles.Contains(posibleOperador))
                {
                    lexema = posibleOperador;
                    Avanzar();
                }
            }

            TipoToken tipo;

            if (lexema == "+" || lexema == "-" ||
                lexema == "*" || lexema == "/" ||
                lexema == "%" || lexema == "++" ||
                lexema == "--")
            {
                tipo = TipoToken.OperadorAritmetico;
            }
            else if (lexema == "==" || lexema == "!=" ||
                     lexema == "<" || lexema == ">" ||
                     lexema == "<=" || lexema == ">=")
            {
                tipo = TipoToken.OperadorRelacional;
            }
            else if (lexema == "&&" || lexema == "||" ||
                     lexema == "!")
            {
                tipo = TipoToken.OperadorLogico;
            }
            else if (lexema == "=" || lexema == "+=" ||
                     lexema == "-=" || lexema == "*=" ||
                     lexema == "/=" || lexema == "%=")
            {
                tipo = TipoToken.OperadorAsignacion;
            }
            else
            {
                RegistrarError(
         "E09",
         lexema,
         lineaInicio,
         columnaInicio,
         "Operador lógico incompleto. Se esperaba && o ||."
     );

                return;
            }

            Token token = new Token(
                numeroToken,
                lexema,
                tipo,
                lineaInicio,
                columnaInicio
            );

            resultado.Tokens.Add(token);
            numeroToken++;
        }
        private void ReconocerComentarioLinea()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();

           
            lexema.Append(CaracterActual());
            Avanzar();

            lexema.Append(CaracterActual());
            Avanzar();

            while (!FinDelCodigo() && CaracterActual() != '\n')
            {
                lexema.Append(CaracterActual());
                Avanzar();
            }

            Token token = new Token(
                numeroToken,
                lexema.ToString(),
                TipoToken.ComentarioLinea,
                lineaInicio,
                columnaInicio
            );

            resultado.Tokens.Add(token);
            numeroToken++;
        }
        private void ReconocerComentarioBloque()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();
            bool cerrado = false;

          
            lexema.Append(CaracterActual());
            Avanzar();

            lexema.Append(CaracterActual());
            Avanzar();

            while (!FinDelCodigo())
            {
                if (CaracterActual() == '*' &&
                    CaracterSiguiente() == '/')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    lexema.Append(CaracterActual());
                    Avanzar();

                    cerrado = true;
                    break;
                }

                lexema.Append(CaracterActual());
                Avanzar();
            }

            if (cerrado)
            {
                Token token = new Token(
                    numeroToken,
                    lexema.ToString(),
                    TipoToken.ComentarioBloque,
                    lineaInicio,
                    columnaInicio
                );

                resultado.Tokens.Add(token);
                numeroToken++;
            }
            else
            {
                RegistrarError(
                    "E07",
                    lexema.ToString(),
                    lineaInicio,
                    columnaInicio,
                    "Comentario de bloque sin cierre."
                );
            }
        }
        private bool EsEscapeValido(char caracter)
        {
            return caracter == 'n' ||
                   caracter == 't' ||
                   caracter == 'r' ||
                   caracter == '\\' ||
                   caracter == '"' ||
                   caracter == '\'' ||
                   caracter == '0';
        }   
        private void RegistrarError(
    string codigo,
    string lexema,
    int lineaError,
    int columnaError,
    string descripcion)
        {
            ErrorLexico error = new ErrorLexico(
                codigo,
                lexema,
                lineaError,
                columnaError,
                descripcion
            );

            resultado.Errores.Add(error);
        }
        private void RegistrarCaracterDesconocido()
        {
            int lineaError = linea;
            int columnaError = columna;
            string lexema = CaracterActual().ToString();

            RegistrarError(
                "E01",
                lexema,
                lineaError,
                columnaError,
                "Carácter no reconocido por el analizador."
            );

            Avanzar();
        }
        private void Avanzar()
        {
            if (FinDelCodigo())
            {
                return;
            }

            char caracter = codigoFuente[posicion];
            posicion++;

            if (caracter == '\r')
            {
                if (!FinDelCodigo() && codigoFuente[posicion] == '\n')
                {
                    posicion++;
                }

                linea++;
                columna = 1;
            }
            else if (caracter == '\n')
            {
                linea++;
                columna = 1;
            }
            else
            {
                columna++;
            }
        }
    }
}
