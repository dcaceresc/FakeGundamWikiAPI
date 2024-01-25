import { ApplicationConfig, importProvidersFrom } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from './app.routes';
import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from "@angular/common/http";
import { AuthorizeInterceptor } from "./core/interceptors/authorize.interceptor";
import { ErrorInterceptor } from "./core/interceptors/error.interceptor";

export const appConfig: ApplicationConfig = {
    providers: [
        importProvidersFrom(BrowserModule,AppRoutingModule),
        provideHttpClient(withInterceptorsFromDi(),withInterceptors([AuthorizeInterceptor,ErrorInterceptor]))
    ]
};