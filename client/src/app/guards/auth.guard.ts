import {CanActivateFn, Router} from '@angular/router';
import {inject} from '@angular/core';
import {CookieService} from 'ngx-cookie-service';
import {UserService} from '../services/user.service';

export const authGuard: CanActivateFn = (route, state) => {
  let cookieService = inject(CookieService)
  const token = cookieService.get('auth_token');
  let userService = inject(UserService)
  let router = inject(Router)
  if (userService.userData() === undefined) {
    router.navigate(['/callback']);
    return false;
  }
  return true;
};
