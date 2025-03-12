import { HttpInterceptorFn } from '@angular/common/http';
import {inject} from '@angular/core';
import {CookieService} from 'ngx-cookie-service';
import {UserService} from '../services/user.service';


export const authInterceptor: HttpInterceptorFn = (req, next) => {

  let cookieService = inject(CookieService)
  let userService = inject(UserService)
  const token = cookieService.get('auth_token');
  if (req.url.includes('webhook')){
    const cloned = req.clone({
      setParams: {email: userService.getTokenData()?.email ?? ''},
    });
    return next(cloned);
  }
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
