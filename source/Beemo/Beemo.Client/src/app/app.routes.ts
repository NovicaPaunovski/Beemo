import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { IntroductionComponent } from './pages/introduction/introduction.component';
import { LogInComponent } from './pages/log-in/log-in.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        title: 'Beemo - Budgets and Expenses Money Organizer'
    },
    {
        path: 'about',
        component: AboutComponent,
        title: 'Beemo - About'
    },
    {
        path: 'introduction',
        component: IntroductionComponent,
        title: 'Beemo - Introduction'
    },
    {
        path: 'log-in',
        component: LogInComponent,
        title: 'Beemo - Log in'
    },
    {
        path: 'sign-up',
        component: LogInComponent,
        title: 'Beemo - Sign up'
    }
];
