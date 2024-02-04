import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from './core/guards/authorize.guard';
import { AdminGuard } from './core/guards/admin.guard';

const routes: Routes = [
  { 
    path: '', 
    loadComponent: () => import('./shared/layouts/frontend-layout/frontend-layout.component').then(m => m.FrontendLayoutComponent),
    children: [
      {
        path: '',
        loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent),
        pathMatch: 'full',
      },
      {
        path: 'docs',
        loadComponent: () => import('./features/docs/docs.component').then(m => m.DocsComponent),
      }
    ]
  },
  {
    path: 'login',
    loadComponent: () => import('./features/administration/security/pages/account/user-login/user-login.component').then(m => m.UserLoginComponent)
  },
  {
    path: 'admin', 
    loadComponent: () => import('./features/administration/security/pages/account/admin-login/admin-login.component').then(m => m.AdminLoginComponent)
  },
  { 
    path : '', 
    loadComponent: () => import('./shared/layouts/backend-layout/backend-layout.component').then(m => m.BackEndLayoutComponent),
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
