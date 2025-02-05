import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { KeycloakAngularModule, KeycloakService } from 'keycloak-angular';
import { initializeKeycloak } from './keycloak-init';
import { KeycloakHttpInterceptor } from './keycloak-http-interceptor.service';

// Rutas de la aplicación
const routes: Routes = [
  { path: '', redirectTo: 'productos', pathMatch: 'full' }, 
  { path: 'productos', loadComponent: () => import('./productos/productos.component').then(m => m.ProductosComponent) },
  { path: 'producto-form', loadComponent: () => import('./producto-form/producto-form.component').then(m => m.ProductoFormComponent) },
  { path: 'login', redirectTo: 'productos', pathMatch: 'full' } // Redirigir a productos
];

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    KeycloakAngularModule // Importamos el módulo de Keycloak
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeKeycloak, // Inicializar Keycloak antes de que arranque la app
      deps: [KeycloakService],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: KeycloakHttpInterceptor,
      multi: true
    }
  ],
  bootstrap: []
})
export class AppModule {}
