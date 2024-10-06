# Gestión de Clientes

# Descripción
Este proyecto es una API RESTful desarrollada en .NET para la gestión de clientes. Proporciona
operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para interactuar con la base de datos de
clientes almacenada en SQL Server.

# Tecnologías Utilizadas
- **.NET SDK**: Framework utilizado para el desarrollo de la API.
- **SQL Server**: Sistema de gestión de bases de datos donde se almacena la información de los clientes.
- **Visual Studio 2022**: Entorno de desarrollo integrado (IDE) para construir y ejecutar la aplicación.
- **Postman**: Herramienta para realizar pruebas de las APIs y enviar solicitudes HTTP.

# Clonación del Repositorio
Para clonar el repositorio, ejecuta los siguientes comandos en tu terminal:
- git clone https://github.com/FernandoGarcia24/gestionClientes.git
- cd gestionVentas

# Instalación de Dependencias
Ejecuta el siguiente comando para instalar las dependencias necesarias:
- dotnet restore

# Configuración del Entorno
- Crea una base de datos en SQL Server llamada Cliente.
- El script para la creación de la tabla se encuentra en la carpeta scripts del proyecto.
- Abre el archivo program.cs y actualiza la cadena de conexión para que apunte a la base de datos creada.

# Migraciones de la Base de Datos
abrir la consola de administracion de paquetes encontrada en Herramientas y ejecuta los siguientes comandos:
- Add-Migration "Primera migracion"
- Update-database

# Ejecución del Proyecto
- Abre el proyecto en Visual Studio 2022.
- Selecciona la opción de ejecución en HTTPS o presiona F5.
- Asegúrate de que la aplicación esté corriendo en modo HTTPS.

# Pruebas de la API
Puedes utilizar Postman o Swagger para probar los endpoints de la API. A continuación, se detallan los endpoints desarrollados:

Endpoints desarrollados:
- POST /api/Clientes: Crea un nuevo cliente.
- GET /api/Clientes: Obtiene todos los clientes.
- GET /api/Clientes/{id}: Obtiene un cliente por ID.
- PUT /api/Clientes/{id}: Actualiza un cliente existente.
- DELETE /api/Clientes/{id}: Elimina un cliente

# Hosting
La API ha sido desplegada en un hosting y está disponible en el siguiente enlace:
- http://www.gestionventasclientes.somee.com/api/Clientes/

# Diagrama de Entidad-Relación
El diagrama de entidad-relación que muestra la estructura de las tablas y sus relaciones
se encuentra en la carpeta docs del proyecto.

