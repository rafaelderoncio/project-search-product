import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withFetch } from '@angular/common/http';

const APP_PROVIDERS: any[] = [
  provideZoneChangeDetection({ eventCoalescing: true }), 
  provideRouter(routes),
  provideHttpClient()
];

export const appConfig: ApplicationConfig = {
  providers: APP_PROVIDERS,
};