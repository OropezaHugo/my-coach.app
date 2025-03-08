import {Component, inject, input, OnInit, signal} from '@angular/core';
import {
  AddExerciseToRoutineData,
  AddRoutineToTrainingPlanData, RoutineExerciseContent,
  TrainingPlanContent, TrainingPlanRoutineContent,
  UserTrainingPlanTrainingPlanCombined
} from '../../models/training-plan.models';
import {TrainingPlanService} from '../../services/training-plan.service';
import {MatAccordion, MatExpansionPanel, MatExpansionPanelHeader} from '@angular/material/expansion';
import {MatButton, MatIconButton} from '@angular/material/button';
import {MatIcon} from '@angular/material/icon';
import {MatDialog} from '@angular/material/dialog';
import {AddRoutineDialogComponent} from '../dialogs/add-routine-dialog/add-routine-dialog.component';
import {EditRoutineDialogComponent} from '../dialogs/edit-routine-dialog/edit-routine-dialog.component';
import {RouterLink} from '@angular/router';
import {AddExerciseDialogComponent} from '../dialogs/add-exercise-dialog/add-exercise-dialog.component';
import {SetActionsDialogComponent} from '../dialogs/set-actions-dialog/set-actions-dialog.component';

@Component({
  selector: 'app-training-plan',
  imports: [
    MatAccordion,
    MatExpansionPanel,
    MatExpansionPanelHeader,
    MatIconButton,
    MatIcon,
    MatButton,
    RouterLink
  ],
  templateUrl: './training-plan.component.html',
  styleUrl: './training-plan.component.scss'
})
export class TrainingPlanComponent implements OnInit {
  userId = input.required<number>();
  trainingPlanId = input.required<number>();
  editable = input.required<boolean>();
  hideEdition = signal<boolean>(false)
  trainingPlanService = inject(TrainingPlanService)
  trainingPlan? : TrainingPlanContent = undefined
  dialog = inject(MatDialog)
  ngOnInit() {
    this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
      next: data => {
        this.trainingPlan = data;
      }
    })
  }

  openAddRoutineDialog(data: AddRoutineToTrainingPlanData) {
    this.dialog.open(AddRoutineDialogComponent, {
      data: data,
    }).afterClosed().subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
          next: data => {
            this.trainingPlan = data;
          }
        })
      }
    })
  }

  deleteRoutineFromTrainingPlan(id: number) {
    this.trainingPlanService.deleteTrainingPlanRoutineById(id).subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
          next: data => {
            this.trainingPlan = data;
          }
        })
      }
    })
  }

  openEditRoutineDialog(routine: TrainingPlanRoutineContent) {
    this.dialog.open(EditRoutineDialogComponent, {
      data: routine
    }).afterClosed().subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
          next: data => {
            this.trainingPlan = data;
          }
        })
      }
    })
  }

  deleteExerciseFromRoutine(id: number) {
    this.trainingPlanService.deleteRoutineExerciseById(id).subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
          next: data => {
            this.trainingPlan = data;
          }
        })
      }
    })
  }

  openAddExerciseDialog(data: AddExerciseToRoutineData) {
    this.dialog.open(AddExerciseDialogComponent, {
      data: data
    }).afterClosed().subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
          next: data => {
            this.trainingPlan = data;
          }
        })
      }
    })
  }


  openSetActionsDialog(data: RoutineExerciseContent) {
    this.dialog.open(SetActionsDialogComponent, {
      data: data,
      minWidth: '500px'
    }).afterClosed().subscribe({
      next: data => {
        this.trainingPlanService.getTrainingPlanContentById(this.trainingPlanId() as number).subscribe({
          next: data => {
            this.trainingPlan = data;
          }
        })
      }
    })
  }
}
