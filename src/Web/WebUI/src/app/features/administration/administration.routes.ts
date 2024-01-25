import { Routes } from "@angular/router";

export const routes: Routes = [
    {
        path: 'mantainers',
        loadChildren: () => import('./mantainers/mantainers.routes').then(m => m.routes)
    },
    {
        path: 'security',
        loadChildren: () => import('./security/security.routes').then(m => m.routes)
    }
];