import {HttpErrorResponse, HttpInterceptorFn} from '@angular/common/http';
import {catchError, throwError} from 'rxjs';
import {Router} from '@angular/router';
import {inject} from '@angular/core';
import {SnackbarService} from '../services/snackbar.service';

export const gatewayErrorInterceptor: HttpInterceptorFn = (req, next) => {
  let snack = inject(SnackbarService)
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 504) {
        switch (req.method) {
          case 'GET':
            snack.error('information asked not saved in cache')
            break;
          case 'POST':
            snack.error('unable to upload data in offline mode')
            break;
          case 'PUT':
            snack.error('unable to update data in offline mode')
            break;
          case 'DELETE':
            snack.error('unable to delete data in offline mode')
            break;
          default:
            snack.error('unable to do this action in offline mode');
        }


      }
      return throwError(() => error);
    })
  );
};
