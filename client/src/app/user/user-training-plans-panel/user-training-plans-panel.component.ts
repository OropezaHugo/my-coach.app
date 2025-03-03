import {Component, inject, input, OnInit} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {UserDietDietCombined} from '../../models/diet.models';
import {MatDialog} from '@angular/material/dialog';
import {TrainingPlanService} from '../../services/training-plan.service';
import {AddTrainingPlanData, UserTrainingPlanTrainingPlanCombined} from '../../models/training-plan.models';
import {UserTrainingPlanCardComponent} from '../user-training-plan-card/user-training-plan-card.component';
import {MatButton} from '@angular/material/button';
import {
  AddTrainingPlanDialogComponent
} from '../../shared/dialogs/add-training-plan-dialog/add-training-plan-dialog.component';

@Component({
  selector: 'app-user-training-plans-panel',
  imports: [
    UserTrainingPlanCardComponent,
    MatButton
  ],
  templateUrl: './user-training-plans-panel.component.html',
  styleUrl: './user-training-plans-panel.component.scss'
})
export class UserTrainingPlansPanelComponent implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  trainingPlanService = inject(TrainingPlanService)
  trainingPlans: UserTrainingPlanTrainingPlanCombined[] = []
  dialog = inject(MatDialog)
  ngOnInit() {
    this.trainingPlanService.getTrainingPlansByUserId(this.userId()).subscribe({
      next: data => {
        this.trainingPlans = data
      }
    })
  }

  openAddTrainingPlanDialog(data: AddTrainingPlanData) {
    this.dialog.open(AddTrainingPlanDialogComponent, {
      data: data,
    }).afterClosed().subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlansByUserId(this.userId()).subscribe({
          next: data => {
            this.trainingPlans = data
          }
        })
      }
    })
  }
}
