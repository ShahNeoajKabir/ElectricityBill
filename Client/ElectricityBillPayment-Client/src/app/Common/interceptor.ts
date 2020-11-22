import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptorService } from './AuthInterceptorService';
import { RequestInterceptorService } from './request-interceptor.service';



export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptorService, multi: true }
];
