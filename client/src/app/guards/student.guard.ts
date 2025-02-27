import {CanActivateFn, Router} from '@angular/router';
import {inject} from '@angular/core';
import {UserService} from '../services/user.service';

export const studentGuard: CanActivateFn = (route, state) => {
  let userService = inject(UserService)
  let router = inject(Router)
  if (userService.userData()?.roleId !== 2) {
    router.navigate(['/guest/home'])
    return false;
  }
  return true;
};
