import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';

import { AppComponent } from './app/app.component';
import { LoginComponent } from './app/login/login.component';
import { ProductosComponent } from './app/productos/productos.component';
import { ProductoFormComponent } from './app/producto-form/producto-form.component';
import { Routes } from '@angular/router';

import { AuthGuard } from './app/auth.guard'; // Guard para autenticación

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'productos', component: ProductosComponent, canActivate: [AuthGuard] }, // se usa el guard para proteger la ruta /productos
  { path: 'producto-form', component: ProductoFormComponent, canActivate: [AuthGuard]  }, // Ruta para el formulario
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(), // Configuración para HttpClient
  ],
}).catch(err => console.error(err));


