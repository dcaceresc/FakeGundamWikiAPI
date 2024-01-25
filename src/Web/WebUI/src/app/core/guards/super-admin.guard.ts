import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthorizeService } from '../services/authorize.service';

export const SuperAdminGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const authorizeService = inject(AuthorizeService);

  if(authorizeService.isSuperAdmin()) {
    return true;
  }

  router.navigate(['/forbidden']);

  return false;
};
