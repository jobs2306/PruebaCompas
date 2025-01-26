import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem('access_token');
    if (token) {
      return true; // El token existe, permitir acceso
    } else {
      this.router.navigate(['/login']); // Redirigir al login si no hay token
      return false;
    }
  }
}
