import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, Observable, catchError, map, of } from 'rxjs';
import { Router } from '@angular/router';
import { AdminLoginRequestCommand, UserLoginRequestCommand, UserTokenResponse } from '../models/security/account.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {
  
  private router = inject(Router);
  private http = inject(HttpClient);

  private userSubject: BehaviorSubject<UserTokenResponse | null>;
  public user: Observable<UserTokenResponse | null>;


  constructor() {
    this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): UserTokenResponse | null {
    return this.userSubject.value;
  }

  public set userValue(user: UserTokenResponse | null) {
    localStorage.setItem('user', JSON.stringify(user));
    this.userSubject.next(user);
  }


  public login(user : UserLoginRequestCommand) {
    return this.http.post<any>('/api/account/login',user )
        .pipe(map(user => {
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
        }));
  }

  public adminLogin(admin : AdminLoginRequestCommand) {
    return this.http.post<any>('/api/account/admin',admin)
        .pipe(map(user => {
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
        }));
  }

  public logout(): void{
    localStorage.removeItem('user');
    this.userSubject.next(null);
    this.router.navigate(['']);
  }

  public refreshToken() : Observable<any> {
    const user = localStorage.getItem('user');

    if (user) {
      const refreshToken = JSON.parse(user).refreshToken;
      return this.http.post<any>('/api/Security/Account/RefreshToken', { refreshToken })
        .pipe(map((user) => {
          localStorage.setItem('user', JSON.stringify(user));
          this.userSubject.next(user);
          return user;
        }),
        catchError(() => of(null)));
    }

    return of(null);
  }

  public getToken() : string | null {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user).accessToken : null;
  }

  private getDecodedTokenClaim(claim: string): string[] {
    const token = this.getToken();

    if (token) {
      const decodedToken = JSON.parse(atob(token.split('.')[1]));
      return decodedToken[claim] || [];
    }

    return [];
  }

  public getRoles(): string[] {
    return this.getDecodedTokenClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
  }

  public isAdmin(): boolean {
    return this.getRoles().includes('Administrador');
  }

  public isSuperAdmin(): boolean {
    return this.getRoles().includes('SuperAdmin');
  }

  public getUserName(): string | null {
    return this.getDecodedTokenClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")[0] || null;
  }

}
