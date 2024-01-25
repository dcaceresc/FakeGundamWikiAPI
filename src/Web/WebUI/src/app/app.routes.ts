import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from './core/guards/authorize.guard';
import { AdminGuard } from './core/guards/admin.guard';

const routes: Routes = [
  { 
    path: '', 
    loadComponent: () => import('./features/administration/security/pages/account/user-login/user-login.component').then(m => m.UserLoginComponent),
    pathMatch: 'full'
  },
  {
    path: 'admin', 
    loadComponent: () => import('./features/administration/security/pages/account/admin-login/admin-login.component').then(m => m.AdminLoginComponent)
  },
  { 
    path : '', 
    loadComponent: () => import('./shared/layouts/main-layout/main-layout.component').then(m => m.MainLayoutComponent),
    canActivate : [AuthorizeGuard], 
    children: [
      {
        path: 'dashboard', 
        loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent)
      },
      {
        path : 'administration', 
        loadChildren: () => import('./features/administration/administration.routes').then(m => m.routes), 
        canActivate: [AdminGuard]
      },
      {
        path: 'forbidden', 
        loadComponent: () => import('./shared/components/forbidden/forbidden.component').then(m => m.ForbiddenComponent)
      },
      {
        path: 'error',
        loadComponent: () => import('./shared/components/error/error.component').then(m => m.ErrorComponent)
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
