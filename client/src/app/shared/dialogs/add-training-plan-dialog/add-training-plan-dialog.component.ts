import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddDietDataToUserDiets} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {AddTrainingPlanData} from '../../../models/training-plan.models';
import {MatAutocomplete, MatAutocompleteTrigger, MatOption} from '@angular/material/autocomplete';
import {MatButton} from '@angular/material/button';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-add-training-plan-dialog',
  imports: [
    MatAutocomplete,
    MatAutocompleteTrigger,
    MatButton,
    MatDialogContent,
    MatFormField,
    MatInput,
    MatLabel,
    MatOption,
    ReactiveFormsModule
  ],
  templateUrl: './add-training-plan-dialog.component.html',
  styleUrl: './add-training-plan-dialog.component.scss'
})
export class AddTrainingPlanDialogComponent {
  dialogRef = inject(MatDialogRef<AddTrainingPlanDialogComponent>);
  data = inject<AddDietDataToUserDiets>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  addTrainingPlanForm = new FormGroup({
    objective: new FormControl<string>('', [Validators.required])
  })

  addTrainingPlanToUser() {
    if (this.addTrainingPlanForm.value.objective) {
      this.trainingPlanService.createTrainingPlan({
        objective: this.addTrainingPlanForm.value.objective
      }).subscribe({
        next: result => {
          this.trainingPlanService.addTrainingPlanToUserTrainingPlans({
            userId: this.data.userId,
            trainingPlanId: result.id,
            assignedDate: new Date().toISOString().split('T')[0],
          }).subscribe({
            next: result => {
              this.dialogRef.close();
            }
          })
        }
      })
    }

  }
}
