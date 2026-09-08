using AnalizadorLexicoCSharp.Modelos;

namespace AnalizadorLexicoCSharp.Analisis
{
    public class AnalizadorLexico
    {
        private readonly TablaSimbolos tablaSimbolos;

        public AnalizadorLexico()
        {
            tablaSimbolos = new TablaSimbolos();
        }

        public ResultadoAnalisis Analizar(
            string codigoFuente)
        {
            tablaSimbolos.Limpiar();

            ResultadoAnalisis resultado =
                new ResultadoAnalisis();

            // El reconocimiento de tokens se implementará
            // después de estudiar autómatas en el curso.

            resultado.Simbolos =
                tablaSimbolos.ObtenerSimbolos();

            return resultado;
        }
    }
}