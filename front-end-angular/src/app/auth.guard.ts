import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { KeycloakService } from 'keycloak-angular'; // 🔹 Importamos KeycloakService

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private keycloakService: KeycloakService) {}

  async canActivate(): Promise<boolean> {
    try {
      const isAuthenticated = await this.keycloakService.isLoggedIn();
      console.log("AuthGuard - Usuario autenticado:", isAuthenticated);

      if (!isAuthenticated) {
        console.warn("Usuario no autenticado. Redirigiendo a Keycloak...");
        await this.keycloakService.login(); // Redirigir a Keycloak
        return false;
      }

      return true;
    } catch (error) {
      console.error("Error en AuthGuard:", error);
      return false;
    }
  }
}
