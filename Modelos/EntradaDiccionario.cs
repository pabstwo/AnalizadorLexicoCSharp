using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexicoCSharp.Modelos
{
    public class EntradaDiccionario
    {
        public string Lexema { get; set; }
        public TipoToken Tipo { get; set; }
        public string Descripcion { get; set; }
        public bool EsTipoDato { get; set; }

        public EntradaDiccionario()
        {
            Lexema = string.Empty;
            Descripcion = string.Empty;
        }

        public EntradaDiccionario(
            string lexema,
            TipoToken tipo,
            string descripcion,
            bool esTipoDato = false)
        {
            Lexema = lexema;
            Tipo = tipo;
            Descripcion = descripcion;
            EsTipoDato = esTipoDato;
        }
    }
}