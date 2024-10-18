
# TO-Do-List Application

## Requisitos
- Visual Studio (Puede ser la versión Community)
- React.js
- Mysql o SQL Server

## Configuración del backend
1. Clonar el repositorio.
2. En Visual Studio abrir la solución de la carpeta CrudAPI.
3. En Visual Studio instalar los paquetes: Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools y Swashbuckle.AspNetCore.
4. Configurar la cadena de conexión en appsettings.json.
5. Ejecutar las migraciones de Entity Framework Core.
6. Iniciar el proyecto.

## Configuración del Frontend
1. Navegar al directorio "appcrud" y ejecutar npm install.
2. Instalar los siguientes paquetes con el comando npm install: cors, --save sweetalert2 sweetalert2-react-content, bootstrap, reactstrap react-dom, sweetalert, y react-router-dom --save.
3. Ejecutar npm start para iniciar la aplicación de React.

## Endpoints de la API
- GET /api/Tarea/lista: Obtener todas las tareas en proceso.
- GET /api/Tarea/lista-completas: Obtener todas las tareas   completadas.
- POST /api/Tarea/agregar: Crear una nueva tarea.
- PUT /api/Tarea/editar/{id}: Actualizar una tarea existente.
- DELETE /api/Tarea/eliminar/{id}: Eliminar una tarea.
