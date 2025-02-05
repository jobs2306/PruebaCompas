import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { provideHttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app/app.component';
import { ProductosComponent } from './app/productos/productos.component';
import { ProductoFormComponent } from './app/producto-form/producto-form.component';

import { KeycloakService } from 'keycloak-angular';
import { KeycloakHttpInterceptor } from './app/keycloak-http-interceptor.service';

// Definir rutas protegidas
const routes: Routes = [
  { path: '', redirectTo: 'productos', pathMatch: 'full' }, // Redirigir a productos
  { path: 'productos', component: ProductosComponent }, // Página de productos
  { path: 'producto-form', component: ProductoFormComponent } // Formulario de productos
];

// Instancia de Keycloak
const keycloak = new KeycloakService();

// Inicializar Keycloak y evitar bucles infinitos
keycloak.init({
  config: {
    url: 'http://localhost:8080', // URL de Keycloak
    realm: 'ApiProductosRealm', // Realm de Keycloak
    clientId: 'BackEndCompas' // ID del cliente Keycloak
  },
  initOptions: {
    onLoad: 'check-sso', // Evita bucles infinitos en login
    checkLoginIframe: false
  }
}).then(async authenticated => {
  console.log("🔹 Keycloak autenticado:", authenticated);

  if (authenticated) {
    if (window.location.pathname === '/') {
      window.location.href = '/productos'; // Solo redirige si está en la raíz
    }
  }
}).catch(error => console.error('Error al inicializar Keycloak:', error));

// Bootstrap de la aplicación Angular
bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: KeycloakHttpInterceptor,
      multi: true
    },
    { provide: KeycloakService, useValue: keycloak }
  ]
}).catch(err => console.error('Error al iniciar la aplicación:', err));
