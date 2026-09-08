namespace AnalizadorLexicoCSharp.Modelos
{
    public class Token
    {
        public int Numero { get; set; }
        public string Lexema { get; set; }
        public TipoToken Tipo { get; set; }
        public int Linea { get; set; }
        public int Columna { get; set; }

        public Token(
            int numero,
            string lexema,
            TipoToken tipo,
            int linea,
            int columna)
        {
            Numero = numero;
            Lexema = lexema;
            Tipo = tipo;
            Linea = linea;
            Columna = columna;
        }
    }
}