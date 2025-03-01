import { Routes } from '@angular/router';
import {LoginComponent} from './auth/login/login.component';
import {CoachHomeComponent} from './coach/home/coach-home.component';
import {authGuard} from './guards/auth.guard';
import {CallbackComponent} from './auth/callback/callback.component';
import {GuestHomeComponent} from './guest/guest-home/guest-home.component';
import {UserHomeComponent} from './user/user-home/user-home.component';
import {studentGuard} from './guards/student.guard';
import {coachGuard} from './guards/coach.guard';
import {StudentProfileComponent} from './coach/students/student-profile/student-profile.component';
import {DietComponent} from './shared/diet/diet.component';
import {input} from '@angular/core';
import {RoutineComponent} from './shared/routine/routine.component';

export const routes: Routes = [
  {path: 'callback', component: CallbackComponent},
  { path: 'coach', canActivate:[authGuard, coachGuard], children: [
      { path: 'home', children: [
          {path: '', component: CoachHomeComponent},
          { path: 'diet/:dietId', component: DietComponent, data: {editable: true}},
        ]
      },
      { path: 'student/:userId', children: [
          {path: '', component: StudentProfileComponent},
          {path: 'diet/:dietId', component: DietComponent, data: {editable: true}},
          {path: 'routine/:routineId', component: RoutineComponent, data: {editable: true}},
        ]
      },
    ]
  },
  { path: 'student', canActivate:[authGuard, studentGuard], children: [
      {path: 'home', children: [
          {path: '', component: UserHomeComponent},
          {path: 'diet/:dietId', component: DietComponent, data: {editable: false}},
        ]
      },
    ]
  },
  { path: 'guest', children: [
      {path: 'home', component: GuestHomeComponent},
    ]
  },

  { path: '**', component: GuestHomeComponent }
];
