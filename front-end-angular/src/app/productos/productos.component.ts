import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
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

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.obtenerProductos();
  }

  obtenerProductos(): void {
    const token = localStorage.getItem('access_token');
    this.http
      .get(`${apiUrl}/Productos`, {
        headers: { Authorization: `Bearer ${token}` },
      })
      .subscribe({
        next: (data: any) => {
          this.productos = data;
        },
        error: (err) => {
          console.error('Error al obtener productos:', err);
        },
      });
  }

  nuevoProducto(): void {
    this.router.navigate(['/producto-form']);
  }

  modificarProducto(id: number): void {
    this.router.navigate(['/producto-form'], { queryParams: { id: id } });
  }

  eliminarProducto(id: number): void {
    if (confirm('¿Estás seguro de eliminar este producto?')) {
      const token = localStorage.getItem('access_token');
      this.http
          .delete(`${apiUrl}/Productos/${id}`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .subscribe({
          next: () => {
            this.obtenerProductos(); // Actualizar la lista de productos
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
    }
  }
  
}
