import {Component, inject, input, OnInit} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {UserDietDietCombined} from '../../models/diet.models';
import {MatDialog} from '@angular/material/dialog';
import {TrainingPlanService} from '../../services/training-plan.service';
import {UserTrainingPlanTrainingPlanCombined} from '../../models/routine.models';
import {UserTrainingPlanCardComponent} from '../user-training-plan-card/user-training-plan-card.component';

@Component({
  selector: 'app-user-training-plans-panel',
  imports: [
    UserTrainingPlanCardComponent
  ],
  templateUrl: './user-training-plans-panel.component.html',
  styleUrl: './user-training-plans-panel.component.scss'
})
export class UserTrainingPlansPanelComponent implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  trainingPlanService = inject(TrainingPlanService)
  routines: UserTrainingPlanTrainingPlanCombined[] = []
  dialog = inject(MatDialog)
  ngOnInit() {
    this.trainingPlanService.getTrainingPlansByUserId(this.userId()).subscribe({
      next: data => {
        this.routines = data
      }
    })
  }
}
