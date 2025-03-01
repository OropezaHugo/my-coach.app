import {Component, input} from '@angular/core';
import {UserTrainingPlanTrainingPlanCombined} from '../../models/routine.models';
import {DatePipe} from '@angular/common';
import {MatButton} from '@angular/material/button';
import {RouterLink, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-user-training-plan-card',
  imports: [
    DatePipe,
    MatButton,
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './user-training-plan-card.component.html',
  styleUrl: './user-training-plan-card.component.scss'
})
export class UserTrainingPlanCardComponent {
  trainingPlan = input.required<UserTrainingPlanTrainingPlanCombined>();
}
