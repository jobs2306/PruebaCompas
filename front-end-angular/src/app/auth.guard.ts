import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import {jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})

export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}
  canActivate(): boolean {
    const token = localStorage.getItem('access_token');
    if (token && !this.isTokenExpired(token)) {
      return true; // El token existe y no ha expirado, permitir acceso
    } else {
      this.router.navigate(['/login']); // Redirigir al login si no hay token o está expirado
      return false;
    }
  }

  private isTokenExpired(token: string): boolean {
    try {
      const decodedToken: any = jwtDecode(token); // Decodifica el token
      const currentTime = Math.floor(Date.now() / 1000); // Tiempo actual en segundos
      return decodedToken.exp < currentTime; // Verifica si ha expirado
    } catch (error) {
      console.error('Error al decodificar el token:', error);
      return true; // Si no se puede decodificar, asumimos que el token es inválido
    }
  }
}
