using AnalizadorLexicoCSharp.Analisis;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string carpetaPruebas = Path.GetFullPath(
    Path.Combine(
        AppContext.BaseDirectory,
        "..", "..", "..", "..",
        "Recursos"
    )
);

string[] archivosPrueba =
{
    "Prueba_1_Sencilla.txt",
    "Prueba_2_Intermedia.txt",
    "Prueba_3_Errores.txt",
    "Prueba_4_NumerosInvalidos.txt",
    "Prueba_5_RecuperacionErrores.txt"
};

Console.WriteLine("PRUEBAS DEL ANALIZADOR LÉXICO");
Console.WriteLine("============================");
Console.WriteLine();

foreach (string nombreArchivo in archivosPrueba)
{
    string rutaArchivo = Path.Combine(carpetaPruebas, nombreArchivo);

    Console.WriteLine($"ARCHIVO: {nombreArchivo}");
    Console.WriteLine(new string('-', 65));

    if (!File.Exists(rutaArchivo))
    {
        Console.WriteLine("No se encontró el archivo de prueba.");
        Console.WriteLine();
        continue;
    }

    string codigoFuente = File.ReadAllText(rutaArchivo);

    AnalizadorLexico analizador = new AnalizadorLexico();
    var resultado = analizador.Analizar(codigoFuente);

    Console.WriteLine($"Tokens encontrados: {resultado.Tokens.Count}");
    Console.WriteLine($"Errores encontrados: {resultado.Errores.Count}");
    Console.WriteLine($"Símbolos encontrados: {resultado.Simbolos.Count}");

    if (resultado.Errores.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("DETALLE DE ERRORES:");

        foreach (var error in resultado.Errores)
        {
            Console.WriteLine(
                $"{error.Codigo} | Lexema: {error.Lexema} | " +
                $"Línea: {error.Linea} | Columna: {error.Columna}"
            );

            Console.WriteLine($"Descripción: {error.Descripcion}");
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("El archivo no contiene errores léxicos.");
    }

    if (resultado.Simbolos.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("TABLA DE SÍMBOLOS:");

        foreach (var simbolo in resultado.Simbolos)
        {
            Console.WriteLine(
                $"{simbolo.Nombre} | Tipo: {simbolo.TipoDato} | " +
                $"Primera línea: {simbolo.PrimeraLinea} | " +
                $"Primera columna: {simbolo.PrimeraColumna} | " +
                $"Apariciones: {simbolo.TotalApariciones}"
            );
        }
    }

    Console.WriteLine();
    Console.WriteLine(new string('=', 65));
    Console.WriteLine();
}

Console.WriteLine("Todas las pruebas finalizaron.");
Console.WriteLine("Presione una tecla para cerrar.");
Console.ReadKey();