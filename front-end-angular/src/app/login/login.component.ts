import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms'; // Para ngModel
import { RouterModule } from '@angular/router'; // Para navegación
import { AppConfig } from '../../config';

const apiUrl = AppConfig.apiUrl;

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterModule], // Aquí indicas los módulos
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  
  onSubmit() {
    const body = { username: this.username, password: this.password };
    this.http.post(`${apiUrl}/Auth/Login`, body).subscribe({
      next: (response: any) => {
        // Guarda el token en el almacenamiento local
        localStorage.setItem('access_token', response.access_token);
        // Redirige a la página de productos
        this.router.navigate(['/productos']);
      },
      error: () => {
        alert('Credenciales incorrectas');
      },
    });
  }
    
}
