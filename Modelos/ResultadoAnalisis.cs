using System.Collections.Generic;

namespace AnalizadorLexicoCSharp.Modelos
{
    public class ResultadoAnalisis
    {
        public List<Token> Tokens { get; set; }
        public List<ErrorLexico> Errores { get; set; }
        public List<Simbolo> Simbolos { get; set; }

        public ResultadoAnalisis()
        {
            Tokens = new List<Token>();
            Errores = new List<ErrorLexico>();
            Simbolos = new List<Simbolo>();
        }
    }
}