import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import { AppConfig } from '../../config';
import { KeycloakService } from 'keycloak-angular';

const apiUrl = AppConfig.apiUrl;

@Component({
  selector: 'app-producto-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './producto-form.component.html',
  styleUrls: ['./producto-form.component.css']
})
export class ProductoFormComponent {
  producto: any = {
    nombre: '',
    descripcion: '',
    precio: 0,
    stock: 0,
  };
  isEditing = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient,
    private keycloakService: KeycloakService // Inyectar KeycloakService
  ) {}

  async ngOnInit(): Promise<void>  {
    // Obtener el parámetro `id` de la URL
    const productoId = this.route.snapshot.queryParamMap.get('id');
    if (productoId) {
      const token = await this.keycloakService.getToken();
      this.isEditing = true; // Está en modo edición
      this.http
      .get(`${apiUrl}/Productos/${productoId}`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .subscribe((data: any) => {
          this.producto = data; // Cargar los datos del producto en el formulario
        });
    }
  }

  /*
  async ngOnInit(): Promise<void> {
    try {
      const productoId = this.route.snapshot.queryParamMap.get('id');
      if (productoId) {
        this.isEditing = true; // Está en modo edición

        const token = await this.keycloakService.getToken(); // Obtener token
        console.log("🔹 Token obtenido:", token);

        this.http
          .get(`${apiUrl}/Productos/${productoId}`, {
            headers: { Authorization: `Bearer ${token}` },
          })
          .subscribe({
            next: (data: any) => {
              console.log("✅ Producto cargado:", data);
              this.producto = data; // Cargar los datos en el formulario
            },
            error: (err) => {
              console.error("❌ Error al obtener producto:", err);
              alert("Error al cargar producto.");
            },
          });
      }
    } catch (error) {
      console.error("⚠️ Error al inicializar el formulario:", error);
    }
  }
    */

  async onSubmit(): Promise<void> {
    const token = await this.keycloakService.getToken();
    
    if (this.isEditing) {
      // Actualizar producto
      this.http.put(`${apiUrl}/Productos/${this.producto.id}`,
          this.producto,
          {
            headers: { Authorization: `Bearer ${token}` },
          }
        )
      .subscribe(() => this.router.navigate(['/productos']),
      (error) => {
        if (error.status == 403){
          alert('No tienes permiso para modificar este producto.');
        }
        else if (error.status == 400) 
        {
          alert(error.error);
        }
        else
        {
          alert('Ocurrió un error al intentar modificar el producto.');
        }
      });
    } else {
      // Crear producto
      this.http.post(`${apiUrl}/Productos`, this.producto, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .subscribe(() => this.router.navigate(['/productos']),
        (error) => {
          if (error.status === 403) {
            alert('No tienes permiso para crear un producto.');
          } 
          else if (error.status == 400) 
          {
            alert(error.error);
          }
          else
          {
            alert('Ocurrió un error al intentar modificar el producto.');
          }
        });
    }
  }
  

  goBack() {
    this.router.navigate(['/productos']);
  }
}
