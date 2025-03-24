import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodGroupToDietData} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {AddRoutineToTrainingPlanData, CreateRoutineData} from '../../../models/training-plan.models';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatOption, MatSelect} from '@angular/material/select';
import {WEEKDAYS} from '../../../models/consts';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-add-routine-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatSelect,
    MatOption,
    MatButton
  ],
  templateUrl: './add-routine-dialog.component.html',
  styleUrl: './add-routine-dialog.component.scss'
})
export class AddRoutineDialogComponent {
  dialogRef = inject(MatDialogRef<AddRoutineDialogComponent>);
  data = inject<AddRoutineToTrainingPlanData>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  addRoutineForm = new FormGroup({
    routineName: new FormControl<string>('', Validators.required),
    routineWeekDay: new FormControl<string>('', [Validators.required]),
    routineArrivalTime: new FormControl<string>('hh:mm', [Validators.required, Validators.pattern('^(?:[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$')])
  })

  addRoutineToTrainingPlan() {
    if (this.addRoutineForm.value.routineName && this.addRoutineForm.value.routineWeekDay && this.addRoutineForm.value.routineArrivalTime) {
      this.trainingPlanService.createRoutine({
        routineName: this.addRoutineForm.value.routineName,
      }).subscribe({
        next: routine => {
          if (this.addRoutineForm.value.routineWeekDay && this.addRoutineForm.value.routineArrivalTime){
            this.trainingPlanService.addRoutineToTrainingPlan({
              routineId: routine.id,
              routineWeekDay: this.addRoutineForm.value.routineWeekDay,
              trainingPlanId: this.data.trainingPlanId,
              arrivalTime: this.addRoutineForm.value.routineArrivalTime,
            }).subscribe({
              next: routine => {
                this.dialogRef.close()
              }
            })
          }
        }
      })
    }
  }

  protected readonly WEEKDAYS = WEEKDAYS;
}
