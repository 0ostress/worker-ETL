-- Proyecto ETL - Análisis de Opiniones

Este proyecto consiste en la implementación de un proceso ETL (Extract, Transform, Load) utilizando .NET 8 mediante un Worker Service.

-- Objetivo

El objetivo es extraer datos desde diferentes fuentes, integrarlos en un solo flujo y prepararlos para su posterior análisis.

-- Fuentes de datos

El sistema obtiene información desde:

-  Archivo CSV (encuestas internas)
-  Base de datos SQL Server (comentarios almacenados)
-  API REST (comentarios externos)

-- Tecnologías utilizadas

- .NET 8
- C#
- SQL Server
- HttpClient
- Worker Service

--Funcionamiento

El Worker Service ejecuta el proceso ETL:

1. Lee datos desde un archivo CSV
2. Consulta datos desde una base de datos
3. Consume datos desde una API REST
4. Unifica todos los datos en una sola colección
5. Guarda los resultados en una capa de staging

--  Estructura del proyecto

- **Worker** → Controla el flujo del ETL
- **Services** → Contiene la lógica (CSV, DB, API)
- **Models** → Define las estructuras de datos

-- Ejecución

Para ejecutar el proyecto:

1. Abrir en Visual Studio
2. Ejecutar el Worker Service (F5)
3. Ver resultados en la consola

-- Notas

- La conexión a la base de datos puede requerir configuración adicional
- La API utilizada es de prueba (JSONPlaceholder)

-- Autor

- Proyecto académico
