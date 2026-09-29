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
        private void ReconocerNumero()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();
            bool esNumeroReal = false;

            while (!FinDelCodigo() && char.IsDigit(CaracterActual()))
            {
                lexema.Append(CaracterActual());
                Avanzar();
            }

            if (!FinDelCodigo() &&
                CaracterActual() == '.' &&
                char.IsDigit(CaracterSiguiente()))
            {
                esNumeroReal = true;

                lexema.Append(CaracterActual());
                Avanzar();

                while (!FinDelCodigo() && char.IsDigit(CaracterActual()))
                {
                    lexema.Append(CaracterActual());
                    Avanzar();
                }
            }

            TipoToken tipo;

            if (esNumeroReal)
            {
                tipo = TipoToken.NumeroReal;
            }
            else
            {
                tipo = TipoToken.NumeroEntero;
            }

            Token token = new Token(
                numeroToken,
                lexema.ToString(),
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

            lexema.Append(CaracterActual());
            Avanzar();

            while (!FinDelCodigo() && CaracterActual() != '\n')
            {
                if (CaracterActual() == '\\')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    if (!FinDelCodigo())
                    {
                        lexema.Append(CaracterActual());
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

            if (cerrada)
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
        }
        private void ReconocerCaracter()
        {
            int lineaInicio = linea;
            int columnaInicio = columna;

            StringBuilder lexema = new StringBuilder();
            bool cerrado = false;

            lexema.Append(CaracterActual());
            Avanzar();

            while (!FinDelCodigo() && CaracterActual() != '\n')
            {
                if (CaracterActual() == '\\')
                {
                    lexema.Append(CaracterActual());
                    Avanzar();

                    if (!FinDelCodigo())
                    {
                        lexema.Append(CaracterActual());
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
                Token token = new Token(
                    numeroToken,
                    lexema.ToString(),
                    TipoToken.Caracter,
                    lineaInicio,
                    columnaInicio
                );

                resultado.Tokens.Add(token);
                numeroToken++;
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