namespace AnalizadorLexicoCSharp.Modelos
{
    public enum TipoToken
    {
        PalabraReservada,
        Identificador,
        NumeroEntero,
        NumeroReal,
        Cadena,
        Caracter,
        OperadorAritmetico,
        OperadorRelacional,
        OperadorLogico,
        OperadorAsignacion,
        Delimitador,
        ComentarioLinea,
        ComentarioBloque,
        FinArchivo,
        Error
    }
}