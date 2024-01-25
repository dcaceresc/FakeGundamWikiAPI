import { HttpRequest, type HttpInterceptorFn, HttpHandlerFn } from '@angular/common/http';
import { AuthorizeService } from '../services/authorize.service';
import { inject } from '@angular/core';
import { catchError, switchMap, throwError } from 'rxjs';


const addToken = (req: HttpRequest<any>, token: string) =>{
  return req.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`,
    },
  });
}

const handleUnauthorizedError = (req: HttpRequest<any>, next: HttpHandlerFn, authorizeService : AuthorizeService) =>{

  const refreshToken = authorizeService.refreshToken();

    if (!refreshToken) {
      // No hay token de actualización, redirigir a la página de inicio de sesión
      authorizeService.logout();
      return throwError(() => 'Usted no esta autorizado, favor comunicarse con el administrador.');
    }

    return refreshToken.pipe(
      switchMap((newUser) => {
        // Token de actualización exitoso, volver a intentar la solicitud con el nuevo token de acceso
        authorizeService.userValue = newUser;
        req = addToken(req, newUser.accessToken);
        return next(req);
      }),
      catchError(() => {
        // No se pudo renovar el token de acceso, redirigir a la página de inicio de sesión
        authorizeService.logout();
        return throwError(() => "Usted no esta autorizado, favor comunicarse con el administrador.");
      })
    );
}


export const AuthorizeInterceptor: HttpInterceptorFn = (req, next) => {

  const authorizeService = inject(AuthorizeService);
  const accessToken = authorizeService.userValue?.accessToken;


  if (accessToken) {
    req = addToken(req, accessToken);
  }


  return next(req).pipe(
    catchError((error) => {
      if (error.status === 401) {
        // Token de acceso expirado, intentar renovar
        return handleUnauthorizedError(req, next,authorizeService);
      }
      return throwError(() => error);
    })
  );
};




