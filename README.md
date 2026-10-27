# Analizador Léxico de C#

Proyecto desarrollado en C# mediante Windows Forms para reconocer los
componentes léxicos de un subconjunto simplificado del lenguaje C#.

## Integrantes

- Andreé Sebastián Choc Ligorria - 202345235
- Pablo Josué Stwolinsky Yat - 202240095
- Jose Gabriel Guadalupe Chiquin Rodriguez - 202344384

## Estructura inicial

- Analisis: contiene las clases relacionadas con el análisis léxico.
- Modelos: contiene los modelos de tokens, errores y símbolos.
- Formularios: contiene la interfaz gráfica del programa.
- Recursos: almacenará archivos utilizados por la aplicación.

## Estado del proyecto

El analizador léxico se encuentra integrado con una interfaz gráfica desarrollada en Windows Forms.

Actualmente permite:

- Escribir o cargar código fuente desde archivos `.cs` y `.txt`.
- Analizar palabras reservadas, identificadores, números, cadenas, caracteres, operadores y delimitadores.
- Mostrar los tokens con su lexema, tipo, línea y columna.
- Detectar y describir errores léxicos.
- Recuperarse de errores y continuar con el análisis.
- Generar una tabla de símbolos con tipos de datos y apariciones.
- Mostrar un resumen de tokens por categoría.
- Mostrar números de línea en el editor.
- Calcular estadísticas y tiempo de ejecución.
- Exportar los resultados del análisis a un archivo CSV.
- Limpiar completamente la interfaz para realizar un nuevo análisis.

También se incluyeron archivos de prueba para validar casos correctos, números inválidos, errores léxicos y recuperación después de errores.