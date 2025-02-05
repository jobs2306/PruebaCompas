import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'productos', pathMatch: 'full' }, // Redirigir a productos
  { path: 'productos', loadComponent: () => import('./productos/productos.component').then(m => m.ProductosComponent) },
  { path: 'producto-form', loadComponent: () => import('./producto-form/producto-form.component').then(m => m.ProductoFormComponent) },
  { path: 'login', redirectTo: '/' } // Redirigir login a la raíz
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
