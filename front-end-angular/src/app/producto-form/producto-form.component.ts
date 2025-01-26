import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 

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
    private http: HttpClient
  ) {}

  ngOnInit() {
    // Obtener el parámetro `id` de la URL
    const productoId = this.route.snapshot.queryParamMap.get('id');
    if (productoId) {
      const token = localStorage.getItem('access_token');
      this.isEditing = true; // Está en modo edición
      this.http
        .get(`http://localhost:5121/api/Productos/${productoId}`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .subscribe((data: any) => {
          this.producto = data; // Cargar los datos del producto en el formulario
        });
    }
  }

  onSubmit() {
    const token = localStorage.getItem('access_token');
    
    if (this.isEditing) {
      // Actualizar producto
      this.http.put(`http://localhost:5121/api/Productos/${this.producto.id}`,
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
        else
        {
          alert('Ocurrió un error al intentar modificar el producto.');
        }
      });
    } else {
      // Crear producto
      this.http.post('http://localhost:5121/api/Productos', this.producto, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .subscribe(() => this.router.navigate(['/productos']),
        (error) => {
          if (error.status === 403) {
            alert('No tienes permiso para crear un producto.');
          } 
          else {
            alert('Ocurrió un error al intentar crear el producto.');
          }
        });
    }
  }
  

  goBack() {
    this.router.navigate(['/productos']);
  }
}
