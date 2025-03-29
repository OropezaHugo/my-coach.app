import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import {provideRouter, withComponentInputBinding} from '@angular/router';

import { routes } from './app.routes';
import { provideServiceWorker } from '@angular/service-worker';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {provideHttpClient, withInterceptors} from '@angular/common/http';
import {authInterceptor} from './interceptors/auth.interceptor';
import {providePrimeNG} from 'primeng/config';
import {gatewayErrorInterceptor} from './interceptors/gateway-error.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection(
      { eventCoalescing: true }
    ),
    provideHttpClient(
      withInterceptors([
        authInterceptor,
        gatewayErrorInterceptor
      ])
    ),
    provideRouter(
      routes,
      withComponentInputBinding()
    ),
    provideServiceWorker(
      'ngsw-worker.js',
      {
        enabled: !isDevMode(),
        registrationStrategy: 'registerWhenStable:30000'
      }
    ),
    provideAnimationsAsync(),
    providePrimeNG(),
  ]
};
