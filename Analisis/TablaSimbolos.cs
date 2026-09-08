using System.Collections.Generic;
using System.Linq;
using AnalizadorLexicoCSharp.Modelos;

namespace AnalizadorLexicoCSharp.Analisis
{
    public class TablaSimbolos
    {
        private readonly Dictionary<string, Simbolo> simbolos;

        public TablaSimbolos()
        {
            simbolos = new Dictionary<string, Simbolo>();
        }

        public void AgregarOActualizar(
            string nombre,
            int linea,
            int columna,
            string tipoDato = "No determinado")
        {
            if (simbolos.ContainsKey(nombre))
            {
                simbolos[nombre].RegistrarAparicion();
            }
            else
            {
                Simbolo nuevoSimbolo = new Simbolo(
                    nombre,
                    linea,
                    columna,
                    tipoDato);

                simbolos.Add(nombre, nuevoSimbolo);
            }
        }
        public List<Simbolo> ObtenerSimbolos()
        {
            return simbolos.Values.ToList();
        }
        public void Limpiar()
        {
            simbolos.Clear();
        }
    }
}