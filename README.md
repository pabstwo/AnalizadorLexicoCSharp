# Analizador Léxico de C#

Aplicación de escritorio desarrollada en C# con Windows Forms para reconocer los componentes léxicos de un subconjunto simplificado del lenguaje C#.

El sistema permite cargar o escribir código fuente, ejecutar el análisis léxico y consultar los tokens, errores y símbolos encontrados. También muestra estadísticas y permite exportar los resultados.

## Integrantes

- Andrée Sebastián Choc Ligorria — 202345235
- Pablo Josué Stwolinsky Yat — 202240095
- José Gabriel Guadalupe Chiquin Rodríguez — 202344384

## Tecnologías utilizadas

- C#
- .NET 8
- Windows Forms
- Visual Studio
- Git
- GitHub

## Funcionalidades

- Escritura manual de código fuente.
- Carga de archivos `.cs` y `.txt`.
- Reconocimiento de palabras reservadas.
- Reconocimiento de identificadores.
- Reconocimiento de números enteros y reales.
- Reconocimiento de cadenas y caracteres.
- Reconocimiento de operadores y delimitadores.
- Reconocimiento de comentarios de línea y de bloque.
- Detección de comentarios de bloque anidados.
- Registro de errores con línea, columna y descripción.
- Recuperación y continuación después de errores léxicos.
- Generación de una tabla de símbolos.
- Cálculo del total de tokens, errores, líneas y tiempo.
- Exportación de resultados a un archivo CSV.
- Validación de entradas vacías.

## Estructura del proyecto

### Analisis

Contiene la lógica principal del análisis léxico.

- `AnalizadorLexico.cs`: recorre el código fuente y reconoce los componentes léxicos.
- `TablaSimbolos.cs`: administra los identificadores encontrados.

### Modelos

Contiene las clases utilizadas para representar los resultados.

- `Token.cs`: representa un token reconocido.
- `TipoToken.cs`: define las categorías de tokens.
- `ErrorLexico.cs`: representa un error y su ubicación.
- `Simbolo.cs`: representa un identificador de la tabla de símbolos.
- `ResultadoAnalisis.cs`: agrupa tokens, errores y símbolos.

### Formularios

Contiene la interfaz gráfica de Windows Forms.

- `FormPrincipal.cs`: administra la interacción con el usuario.
- `FormPrincipal.Designer.cs`: contiene la configuración visual del formulario.

### Recursos

Contiene los archivos utilizados para probar el analizador.

## Funcionamiento general

1. El usuario escribe código o carga un archivo.
2. El formulario valida que exista contenido.
3. El texto se envía al método `Analizar`.
4. El analizador recorre la entrada carácter por carácter.
5. Cada lexema se clasifica mediante un tipo de token.
6. Los errores se registran con su línea y columna.
7. Los identificadores se agregan a la tabla de símbolos.
8. El resultado se devuelve al formulario.
9. Las tablas y estadísticas se actualizan.
10. El usuario puede exportar los resultados a CSV.

## Categorías reconocidas

El analizador reconoce, entre otras, las siguientes categorías:

- Palabras reservadas
- Identificadores
- Números enteros
- Números reales
- Cadenas
- Caracteres
- Operadores aritméticos
- Operadores relacionales
- Operadores lógicos
- Operadores de asignación
- Delimitadores
- Comentarios de línea
- Comentarios de bloque
- Fin de archivo

## Manejo de errores

Cuando se encuentra un elemento incorrecto, el analizador crea un objeto `ErrorLexico` con:

- Código de error
- Lexema o carácter
- Línea
- Columna
- Descripción

Después de registrar el error, el recorrido continúa desde una posición segura. Esto permite encontrar varios errores durante una sola ejecución.

### Comentarios anidados

Los comentarios de bloque anidados no son válidos en el subconjunto analizado. Cuando aparece otro `/*` dentro de un comentario de bloque, se registra el error `E08`.

El analizador utiliza un contador de profundidad para conservar el contenido como comentario hasta encontrar los cierres correspondientes. Esto evita que las palabras internas sean reconocidas incorrectamente como tokens independientes.

## Manual de usuario

### Cargar código

1. Ejecutar el proyecto `AnalizadorLexicoCSharp`.
2. Presionar **Cargar Archivo**.
3. Seleccionar un archivo `.cs` o `.txt`.
4. Confirmar que el contenido aparezca en Código Fuente.

### Analizar código

1. Escribir o cargar código.
2. Presionar **Analizar**.
3. Consultar las pestañas Tokens, Errores y Tabla de símbolos.
4. Revisar las estadísticas en la parte inferior.

### Limpiar resultados

Presionar **Limpiar** para borrar el código, las tablas y los contadores.

### Exportar resultados

1. Ejecutar un análisis.
2. Presionar **Exportar**.
3. Elegir el nombre y la ubicación.
4. Guardar el archivo CSV.

## Batería de pruebas

| Caso | Archivo | Propósito | Resultado obtenido | Estado |
|---|---|---|---|---|
| CP01 | `Prueba_1_Sencilla.txt` | Declaraciones y literales válidos | 26 tokens, 0 errores, 5 líneas | Aprobado |
| CP02 | `Prueba_2_Intermedia.txt` | Entrada válida de mayor extensión | 50 tokens, 0 errores, 21 líneas | Aprobado |
| CP03 | `Prueba_3_Errores.txt` | Errores léxicos combinados | 32 tokens, 8 errores, 8 líneas | Aprobado |
| CP04 | `Prueba_4_NumerosInvalidos.txt` | Números e identificadores inválidos | 18 tokens, 3 errores, 8 líneas | Aprobado |
| CP05 | `Prueba_5_RecuperacionErrores.txt` | Continuación después de errores | 22 tokens, 3 errores, 8 líneas | Aprobado |
| CP06 | `Prueba_6_OperadoresYDelimitadores.txt` | Operadores y delimitadores | 67 tokens, 0 errores, 13 líneas | Aprobado |
| CP07 | `Prueba_7_CadenasYCaracteres.txt` | Cadenas, caracteres y escapes | 31 tokens, 0 errores, 6 líneas | Aprobado |
| CP08 | `Prueba_8_Comentarios.txt` | Comentarios válidos | 15 tokens, 0 errores, 8 líneas | Aprobado |
| CP09 | `Prueba_9_CasosLimite.txt` | Casos límite y comentario anidado | 17 tokens, 1 error, 7 líneas | Aprobado |
| CP10 | `Prueba_10_ComentarioSinCerrar.txt` | Comentario de bloque sin cierre | 6 tokens, 1 error, 4 líneas | Aprobado |
| CP11 | `Prueba_11_MultiplesErrores.txt` | Múltiples errores en una entrada | 32 tokens, 8 errores, 9 líneas | Aprobado |
| CP12 | `Prueba_12_EntradaVacia.txt` | Validación de entrada vacía | Advertencia y análisis cancelado | Aprobado |

## Compilación

La solución contiene dos proyectos:

- `AnalizadorLexicoCSharp`
- `PruebasAnalizadorLexico`

Resultado de la recompilación final:

```text
Recompilar todo: 2 correctos, 0 errores, 0 omitidos
```

## Control de versiones

El proyecto utiliza ramas de Git para separar cada etapa de desarrollo.

Para el Entregable 5 se utilizó la rama:

```text
entregable-5
```

Los cambios fueron integrados a `master` mediante el Pull Request número 4, después de completar la batería de pruebas y verificar que no existieran conflictos.

## Ejecución del proyecto

1. Clonar o descargar el repositorio.
2. Abrir `AnalizadorLexicoCSharp.sln` en Visual Studio.
3. Restaurar las dependencias.
4. Establecer `AnalizadorLexicoCSharp` como proyecto de inicio.
5. Recompilar la solución.
6. Ejecutar la aplicación.

## Estado del proyecto

El analizador léxico se encuentra funcional y validado mediante doce casos de prueba. El código está integrado en la rama `master` y preparado para su publicación como versión final.