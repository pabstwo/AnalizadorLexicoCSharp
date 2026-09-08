namespace AnalizadorLexicoCSharp.Modelos
{
    public class ErrorLexico
    {
        public string Codigo { get; set; }
        public string Lexema { get; set; }
        public int Linea { get; set; }
        public int Columna { get; set; }
        public string Descripcion { get; set; }

        public ErrorLexico(
            string codigo,
            string lexema,
            int linea,
            int columna,
            string descripcion)
        {
            Codigo = codigo;
            Lexema = lexema;
            Linea = linea;
            Columna = columna;
            Descripcion = descripcion;
        }
    }
}