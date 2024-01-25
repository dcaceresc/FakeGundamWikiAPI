import { Router, type CanActivateFn } from '@angular/router';
import { AuthorizeService } from '../services/authorize.service';
import { inject } from '@angular/core';

export const AdminGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const authorizeService = inject(AuthorizeService);


  if(authorizeService.isAdmin() || authorizeService.isSuperAdmin()) {
    return true;
  }

  router.navigate(['/forbidden']);

  return false;
};
