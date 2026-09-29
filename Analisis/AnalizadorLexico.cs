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
                else
                {
                    Avanzar();
                }
            }

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
                    columnaInicio
                );
            }
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