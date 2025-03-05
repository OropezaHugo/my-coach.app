import { HttpInterceptorFn } from '@angular/common/http';
import {inject} from '@angular/core';
import {CookieService} from 'ngx-cookie-service';


export const authInterceptor: HttpInterceptorFn = (req, next) => {
  let cookieService = inject(CookieService)
  const token = cookieService.get('auth_token');
  if (token) {
    const cloned = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      },
      withCredentials: true
    });
    return next(cloned);
  }
  return next(req);
};
