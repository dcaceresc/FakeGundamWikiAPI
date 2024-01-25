import { Routes } from "@angular/router";
import { SuperAdminGuard } from "../../../core/guards/super-admin.guard";

export const routes: Routes = [
    {
        path: 'users', 
        loadChildren: () => import('./pages/users/users.routes').then(m => m.routes),
    },
    {
        path: 'roles', 
        loadChildren: () => import('./pages/roles/roles.routes').then(m => m.routes),
        canActivate: [SuperAdminGuard]
    }
];