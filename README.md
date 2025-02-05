# PruebaCompas

### Configuración y ejecución de Keycloak

#### Usuario

```bash
set KEYCLOAK_ADMIN=admin
set KEYCLOAK_ADMIN_PASSWORD=admin
```

#### Nombre de Realm a crear

- **Nombre sugerido:** `ApiProductosRealm`
  - Si decides usar un nombre diferente, asegúrate de actualizarlo en el archivo `Program.cs` del proyecto .NET y en la configuración de la aplicación WinForms.

#### Crear un cliente (la API) que se conectará

- **Nombre sugerido:** `BackEndCompas`
- **Dirección Root:** `http://localhost:5121` (para ejecución local)
- Activar `Client authentication` y `Authorization`

#### Crear usuarios

1. Crear un usuario escritor con el rol `writer`
2. Crear un usuario lector con el rol `reader`
   - Los roles se crean en el cliente configurado previamente.
   - Asignar contraseñas a los usuarios en la sección de credenciales y desactivar la opción `Temporary`.

#### Policies

- Dentro del cliente creado, dirígete a `Authorization` > `Policies`.
- Agregar dos políticas:
  1. Una para leer.
  2. Otra para escribir.

#### Permissions

- Dentro del cliente creado, dirígete a `Authorization` > `Permissions`.
- Crear dos permisos:
  1. Uno para leer, asociado a la política de lectura.
  2. Otro para escribir, asociado a la política de escritura.

#### Exportar configuración de Keycloak

- Para exportar la configuración actual:
  ```bash
  bin/kc.bat export --dir=exports --users=realm_file
  ```
- Para ejecutar modo dev:
  ```bash
  bin\kc.bat start-dev
  ```

#### Importar configuración de Keycloak

- Para ejecutar Keycloak importando la configuración exportada:
  ```bash
  bin/kc.bat start --import-realm
  ```
- Nota: En la carpeta `exports`, se generará un archivo de configuración que puedes usar para evitar configuraciones manuales futuras.

---

### Configuración de la base de datos

1. Asegúrate de tener MySQL instalado en tu máquina local.
2. Crea una base de datos llamada `productos`.
3. Configura un usuario con permisos adecuados (por ejemplo, `root` con contraseña `1194`).

#### Migraciones de la base de datos

1. Abre una terminal en la raíz del proyecto.
2. Ejecuta los siguientes comandos:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
   - Esto creará las tablas necesarias en la base de datos `productos`.

---

### Configuración de la API

#### Construir y ejecutar la API con .NET

1. Abre una terminal y navega a la carpeta raíz del proyecto.
2. Ejecuta los siguientes comandos:
   ```bash
   dotnet restore
   dotnet build -c Release
   dotnet run
   ```
3. La API estará disponible en `http://localhost:5121`.

#### Configurar variable de entorno

- Configura la variable de entorno para el `CLIENT_SECRET`:
  ```bash
  setx CLIENT_SECRET "tu_client_secret_aqui"
  ```
  - Obtén la clave secreta desde las credenciales del cliente creado en Keycloak.

---

### Configuración de la aplicación WinForms

1. Dirígete al archivo `Program.cs` y actualiza la URL de la API REST.
2. Abre el proyecto en Visual Studio.
3. Ejecuta la aplicación desde Visual Studio.

---

### Configuración de la aplicación Angular

1. Abre el archivo de configuración en el proyecto Angular y actualiza el valor de `apiUrl` con la URL de la API REST (`http://localhost:5121`).
2. En una terminal, navega a la carpeta del proyecto Angular.
3. Ejecuta el siguiente comando para iniciar la aplicación:
   ```bash
   ng serve
   ```
4. La aplicación estará disponible en `http://localhost:4200`.