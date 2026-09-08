namespace AnalizadorLexicoCSharp.Modelos
{
    public class Simbolo
    {
        public string Nombre { get; set; }
        public int PrimeraLinea { get; set; }
        public int PrimeraColumna { get; set; }
        public string TipoDato { get; set; }
        public int TotalApariciones { get; set; }

        public Simbolo(
            string nombre,
            int primeraLinea,
            int primeraColumna,
            string tipoDato)
        {
            Nombre = nombre;
            PrimeraLinea = primeraLinea;
            PrimeraColumna = primeraColumna;
            TipoDato = tipoDato;
            TotalApariciones = 1;
        }

        public void RegistrarAparicion()
        {
            TotalApariciones++;
        }
    }
}