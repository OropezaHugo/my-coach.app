import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodGroupToDietData} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {AddExerciseToRoutineData, ExerciseModel} from '../../../models/training-plan.models';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton} from '@angular/material/button';
import {MatOption, MatSelect} from '@angular/material/select';

@Component({
  selector: 'app-add-exercise-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatButton,
    MatSelect,
    MatOption
  ],
  templateUrl: './add-exercise-dialog.component.html',
  styleUrl: './add-exercise-dialog.component.scss'
})
export class AddExerciseDialogComponent implements OnInit{
  dialogRef = inject(MatDialogRef<AddExerciseDialogComponent>);
  data = inject<AddExerciseToRoutineData>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  exercises: ExerciseModel[] = []
  addExerciseForm = new FormGroup({
    exerciseName: new FormControl<string>('', Validators.required),
    exerciseEffort: new FormControl<number>(1, Validators.required),
  })

  ngOnInit() {
    this.trainingPlanService.getExercises().subscribe({
      next: data => {
        this.exercises = data;
      }
    })
  }

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
