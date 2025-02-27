import { Routes } from '@angular/router';
import {LoginComponent} from './auth/login/login.component';
import {CoachHomeComponent} from './coach/home/coach-home.component';
import {authGuard} from './guards/auth.guard';
import {CallbackComponent} from './auth/callback/callback.component';
import {GuestHomeComponent} from './guest/guest-home/guest-home.component';
import {UserHomeComponent} from './user/user-home/user-home.component';
import {studentGuard} from './guards/student.guard';
import {coachGuard} from './guards/coach.guard';

export const routes: Routes = [
  {path: 'callback', component: CallbackComponent},
  { path: 'coach', canActivate:[authGuard, coachGuard], children: [
      { path: 'home', component: CoachHomeComponent },
    ]
  },
  { path: 'student', canActivate:[authGuard, studentGuard], children: [
      {path: 'home', component: UserHomeComponent},
    ]
  },
  { path: 'guest', children: [
      {path: 'home', component: GuestHomeComponent},
    ]
  },

  { path: '**', component: GuestHomeComponent }
];
