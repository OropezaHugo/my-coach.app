import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodGroupToDietData} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {AddExerciseToRoutineData} from '../../../models/training-plan.models';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-add-exercise-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatButton
  ],
  templateUrl: './add-exercise-dialog.component.html',
  styleUrl: './add-exercise-dialog.component.scss'
})
export class AddExerciseDialogComponent {
  dialogRef = inject(MatDialogRef<AddExerciseDialogComponent>);
  data = inject<AddExerciseToRoutineData>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  addExerciseForm = new FormGroup({
    exerciseName: new FormControl<string>('', Validators.required),
    exerciseEffort: new FormControl<number>(1, Validators.required),
  })

  addExerciseToRoutine() {
    if (this.addExerciseForm.value.exerciseName && this.addExerciseForm.value.exerciseEffort) {
      this.trainingPlanService.createExercise({
        exerciseName: this.addExerciseForm.value.exerciseName,
      }).subscribe({
        next: (exercise) => {
          if (this.addExerciseForm.value.exerciseEffort){
            this.trainingPlanService.addExerciseToRoutine({
              exerciseId: exercise.id,
              routineId: this.data.routineId,
              effort: this.addExerciseForm.value.exerciseEffort,
            }).subscribe({
              next: (exercise) => {
                this.dialogRef.close()
              }
            });
          }

        }
      })
    }
  }
}
