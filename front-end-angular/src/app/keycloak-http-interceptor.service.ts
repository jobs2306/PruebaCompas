import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { KeycloakService } from 'keycloak-angular';

@Injectable()
export class KeycloakHttpInterceptor implements HttpInterceptor {

  constructor(private keycloakService: KeycloakService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return from(this.handleRequest(req, next));
  }

  private async handleRequest(req: HttpRequest<any>, next: HttpHandler): Promise<HttpEvent<any>> {
    try {
      const token = await this.keycloakService.getToken();
      
      // Si no hay token, continuar con la solicitud sin modificarla
      if (!token) {
        return next.handle(req).toPromise() as Promise<HttpEvent<any>>;
      }

      // Clonar la petición y agregar el token en los headers
      const cloned = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });

      return next.handle(cloned).toPromise() as Promise<HttpEvent<any>>;

    } catch (error) {
      console.error("Error al obtener el token de Keycloak:", error);
      return next.handle(req).toPromise() as Promise<HttpEvent<any>>;
    }
  }
}
