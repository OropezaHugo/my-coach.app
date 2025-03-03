import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {FoodGroupAndContentModel} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {TrainingPlanRoutineContent} from '../../../models/training-plan.models';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {FormControl, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {WEEKDAYS} from '../../../models/consts';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-edit-routine-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatSelect,
    ReactiveFormsModule,
    MatOption,
    MatButton
  ],
  templateUrl: './edit-routine-dialog.component.html',
  styleUrl: './edit-routine-dialog.component.scss'
})
export class EditRoutineDialogComponent {
  dialogRef = inject(MatDialogRef<EditRoutineDialogComponent>);
  data = inject<TrainingPlanRoutineContent>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  routineWeekDayForm = new FormControl<string>('', Validators.required);

  editRoutineInTrainingPlan() {
    if (this.routineWeekDayForm.value) {
      this.trainingPlanService.updateTrainingPlanRoutineById(this.data.id, {
        trainingPlanId: this.data.trainingPlanId,
        routineId: this.data.routineId,
        routineWeekDay: this.routineWeekDayForm.value
      }).subscribe({
        next: data => {
          this.dialogRef.close()
        }
      })
    }
  }

  protected readonly WEEKDAYS = WEEKDAYS;
}
