import { Routes } from '@angular/router';
import { LoginComponent } from './presentation/pages/login/login.component';
import { AuthGuard } from './infraestructure/services/auth.guard';
import { LoginGuard } from './infraestructure/services/login.guard';
import { BooksComponent } from './presentation/pages/books/books.component';
import { AuthorsComponent } from './presentation/pages/authors/authors.component';
import { AuthLayoutComponent } from './presentation/layout/auth-layout/auth-layout.component';
import { LoggedLayoutComponent } from './presentation/layout/logged-layout/logged-layout.component';
import { RegisterComponent } from './presentation/pages/register/register.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: '/login',
        pathMatch: 'full'
    },
    {
        path: '',
        component: AuthLayoutComponent,
        canActivate: [LoginGuard],
        children: [
            {
                path: 'login',
                component: LoginComponent
            },
            {
                path: 'register',
                component: RegisterComponent
            }
        ]
    },
    {
        path: '',
        component: LoggedLayoutComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path: 'books',
                component: BooksComponent
            },
            {
                path: 'authors',
                component: AuthorsComponent
            }
        ]
    },
    { path: '**', redirectTo: '/login' }
];
