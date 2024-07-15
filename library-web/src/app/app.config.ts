import { ApplicationConfig } from '@angular/core';
import { HTTP_INTERCEPTORS, withInterceptorsFromDi } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { AuthApiService } from './infraestructure/api/login.service';
import { BooksApiService } from './infraestructure/api/books.service';
import { AuthService } from './infraestructure/services/auth.service';
import { AuthInterceptor } from './infraestructure/interceptor/auth.interceptor';
import { LoanUsesCases } from './domain/usecases/loanUseCases';
import { LoanApiService } from './infraestructure/api/loan.service';
import { BooksGateway } from './domain/gateway/books.gateway';
import { AuthGateway } from './domain/gateway/login.gateway';
import { LoanGateway } from './domain/gateway/loan.gateway';
import { provideAnimations } from '@angular/platform-browser/animations';

import { provideToastr } from 'ngx-toastr';
import { AuthorsGateway } from './domain/gateway/authors.gateway';
import { AuthorsApiService } from './infraestructure/api/authors.service';
import { provideIcons } from '@ng-icons/core';
import { heroPlusCircleSolid, heroTrashSolid } from '@ng-icons/heroicons/solid';


export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    { provide: AuthGateway, useClass: AuthApiService },
    { provide: BooksGateway, useClass: BooksApiService },
    { provide: LoanGateway, useClass: LoanApiService },
    { provide: AuthorsGateway, useClass: AuthorsApiService },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    provideAnimations(),
    provideToastr(),
    provideIcons({ heroPlusCircleSolid, heroTrashSolid })
  ]
};
