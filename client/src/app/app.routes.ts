import { Routes } from '@angular/router';
import {CoachHomeComponent} from './coach/home/coach-home.component';
import {authGuard} from './guards/auth.guard';
import {CallbackComponent} from './auth/callback/callback.component';
import {GuestHomeComponent} from './guest/guest-home/guest-home.component';
import {UserHomeComponent} from './user/user-home/user-home.component';
import {studentGuard} from './guards/student.guard';
import {coachGuard} from './guards/coach.guard';
import {StudentProfileComponent} from './coach/students/student-profile/student-profile.component';
import {DietComponent} from './shared/diet/diet.component';
import {TrainingPlanComponent} from './shared/training-plan/training-plan.component';
import {FoodComponent} from './shared/food/food.component';
import {PrizeComponent} from './shared/prize/prize.component';
import {PublicProfilePanelComponent} from './user/public-profile-panel/public-profile-panel.component';
import {StudentsPanelComponent} from './coach/students/students-panel/students-panel.component';

export const routes: Routes = [
  {path: 'callback', component: CallbackComponent},
  {path: 'community', component: PublicProfilePanelComponent},
  { path: 'coach', canActivate:[authGuard, coachGuard], children: [
      { path: 'home', children: [
          {path: '', component: CoachHomeComponent},
          { path: 'diet/:dietId', component: DietComponent, data: {editable: true}},
        ]
      },
      {path: 'prizes', component: PrizeComponent},
      {path: 'students', component: StudentsPanelComponent},
      { path: 'student/:userId', children: [
          {path: '', component: StudentProfileComponent},
          {path: 'diet/:dietId', component: DietComponent, data: {editable: true}},
          {path: 'training-plan/:trainingPlanId', component: TrainingPlanComponent, data: {editable: true}},
        ]
      },
    ]
  },
  { path: 'student', canActivate:[authGuard, studentGuard], children: [
      {path: 'home', children: [
          {path: '', component: UserHomeComponent},
          {path: 'diet/:dietId', component: DietComponent, data: {editable: false}},
          {path: 'training-plan/:trainingPlanId', component: TrainingPlanComponent, data: {editable: false}},
        ]
      },
    ]
  },
  { path: 'guest', children: [
      {path: 'home', component: GuestHomeComponent},
    ]
  },
  {path: 'food', component: FoodComponent},
  { path: '**', component: GuestHomeComponent }
];
