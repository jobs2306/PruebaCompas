import { KeycloakService } from 'keycloak-angular';

export function initializeKeycloak(keycloak: KeycloakService) {
  return () =>
    keycloak.init({
      config: {
        url: 'http://localhost:8080', // URL del servidor de Keycloak
        realm: 'ApiProductosRealm', // Nombre del realm en Keycloak
        clientId: 'BackEndCompas' // Nombre del cliente en Keycloak
      },
      initOptions: {
        onLoad: 'login-required',  // 🔹 Asegurar que Keycloak obliga a iniciar sesión
        checkLoginIframe: false
      },
      bearerExcludedUrls: ['/assets']
    });
}
