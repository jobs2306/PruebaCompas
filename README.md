# PruebaCompas

#### Ejecución de keycloak

# Usuario
set KEYCLOAK_ADMIN=admin
set KEYCLOAK_ADMIN_PASSWORD=admin

# Ejecución
bin/kc.bat start-dev

# para exportar
bin/kc.bat export --dir=exports --users=realm_file

bin\kc.bat start --import-realm

# ejecutar usando el directorio exportado
kc.bat export --dir=exports --users=realm_file --optimized

# Configurar variable de entorno
setx CLIENT_SECRET "tu_client_secret_aqui"
