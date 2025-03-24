import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {FoodGroupAndContentModel} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {TrainingPlanRoutineContent} from '../../../models/training-plan.models';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {WEEKDAYS} from '../../../models/consts';
import {MatButton} from '@angular/material/button';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-edit-routine-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatSelect,
    ReactiveFormsModule,
    MatOption,
    MatButton,
    MatInput
  ],
  templateUrl: './edit-routine-dialog.component.html',
  styleUrl: './edit-routine-dialog.component.scss'
})
export class EditRoutineDialogComponent {
  dialogRef = inject(MatDialogRef<EditRoutineDialogComponent>);
  data = inject<TrainingPlanRoutineContent>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  routineForm = new FormGroup({
    routineWeekDayForm: new FormControl<string>('', Validators.required),
    routineArrivalTime: new FormControl<string>('hh:mm', [Validators.required, Validators.pattern('^(?:[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$')])
  })


  editRoutineInTrainingPlan() {
    if (this.routineForm.value.routineWeekDayForm && this.routineForm.value.routineArrivalTime) {
      this.trainingPlanService.updateTrainingPlanRoutineById(this.data.id, {
        trainingPlanId: this.data.trainingPlanId,
        routineId: this.data.routineId,
        routineWeekDay: this.routineForm.value.routineWeekDayForm,
        arrivalTime: this.routineForm.value.routineArrivalTime
      }).subscribe({
        next: data => {
          this.dialogRef.close()
        }
      })
    }
  }

  protected readonly WEEKDAYS = WEEKDAYS;
}
