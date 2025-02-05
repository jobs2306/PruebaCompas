import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { KeycloakService } from 'keycloak-angular';
import { AppConfig } from '../../config';

const apiUrl = AppConfig.apiUrl;

@Component({
  selector: 'app-productos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  
  productos: any[] = [];

  constructor(
    private http: HttpClient, 
    private router: Router,
    private keycloakService: KeycloakService
  ) {}

  async ngOnInit(): Promise<void> {
    try {
      // 🔹 Esperar 500ms para asegurarnos que Keycloak determinó el estado de autenticación
      await new Promise(resolve => setTimeout(resolve, 200));

      const isAuthenticated = await this.keycloakService.isLoggedIn();
      console.log("Keycloak autenticado:", isAuthenticated);

      if (!isAuthenticated) {
        console.warn("No autenticado. Redirigiendo a Keycloak...");
        await this.keycloakService.login();
        return;
      }

      const token = await this.keycloakService.getToken();
      console.log("Token obtenido:", token);

      if (token) {
        this.obtenerProductos(token);
      } else {
        console.warn("No se obtuvo token válido.");
      }
    } catch (error) {
      console.error("Error verificando autenticación:", error);
    }
  }

  async obtenerProductos(token: string): Promise<void> {
    this.http.get(`${apiUrl}/Productos`, {
        headers: { Authorization: `Bearer ${token}` }
      }).subscribe({
        next: (data: any) => {
          console.log("Productos obtenidos:", data);
          this.productos = data;
        },
        error: (err) => {
          console.error("Error al obtener productos:", err);
          if (err.status === 401) {
            console.warn("Token expirado. Redirigiendo a login...");
            this.keycloakService.logout();
          }
        }
      });
  }

  nuevoProducto(): void {
    this.router.navigate(['/producto-form']);
  }

  modificarProducto(id: number): void {
    this.router.navigate(['/producto-form'], { queryParams: { id: id } });
  }

  async eliminarProducto(id: number): Promise<void> {
    if (confirm('¿Estás seguro de eliminar este producto?')) {
      try {
        const token = await this.keycloakService.getToken(); 
        if (!token) {
          console.warn("No se pudo obtener el token para eliminar.");
          await this.keycloakService.login();
          return;
        }

        this.http
          .delete(`${apiUrl}/Productos/${id}`, {
            headers: { Authorization: `Bearer ${token}` },
          })
          .subscribe({
            next: () => {
              console.log(`Producto con ID ${id} eliminado.`);
              this.obtenerProductos(token);
            },
            error: (err) => {
              if (err.status === 403) {
                alert('No tienes permiso para eliminar un producto.');
              } else {
                alert('Ocurrió un error al intentar eliminar el producto.');
              }
              console.error('Error al eliminar producto:', err);
            },
          });
      } catch (error) {
        console.error("Error al obtener el token:", error);
      }
    }
  }
}
