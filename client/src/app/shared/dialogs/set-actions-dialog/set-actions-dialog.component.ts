import {Component, inject, OnInit, signal} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {
  RoutineExerciseContent,
  SetActionsData, SetData,
  SetModel,
  TrainingPlanRoutineContent
} from '../../../models/training-plan.models';
import {TrainingPlanService} from '../../../services/training-plan.service';
import {MatIcon} from '@angular/material/icon';
import {MatButton, MatIconButton} from '@angular/material/button';
import {MatTabGroup} from '@angular/material/tabs';
import {FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-set-actions-dialog',
  imports: [
    MatDialogContent,
    MatIcon,
    MatIconButton,
    MatTabGroup,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatButton
  ],
  templateUrl: './set-actions-dialog.component.html',
  styleUrl: './set-actions-dialog.component.scss'
})
export class SetActionsDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<SetActionsDialogComponent>);
  data = inject<SetActionsData>(MAT_DIALOG_DATA);
  trainingPlanService = inject(TrainingPlanService)
  editing = signal<boolean>(false)
  activeSet? : SetModel = undefined
  sets: SetModel[] = []
  editSetForm = new FormGroup({
    setRepetitions: new FormControl<number>(1, [Validators.required, Validators.min(1)]),
    setWeight: new FormControl<number>(0, [Validators.required]),
  })
  ngOnInit() {
    this.trainingPlanService.getSetsByExerciseId(this.data.exerciseId).subscribe({
      next: data => {
        this.sets = data
        if (this.sets.length > 0) {
          this.activeSet = data[data.length - 1]
        }
      }
    })
  }

  addSet() {
    if (this.sets.length > 0) {
      this.activeSet = this.sets[this.sets.length - 1]
    }
    this.trainingPlanService.createSet(this.activeSet ?? {
      weight: 0,
      repetitions: 0
    }).subscribe({
      next: set => {
        this.trainingPlanService.addSetToExercise({
          exerciseId: this.data.exerciseId,
          setId: set.id,
          fatigue: 0
        }).subscribe({
          next: data => {
            this.trainingPlanService.getSetsByExerciseId(this.data.exerciseId).subscribe({
              next: data => {
                this.sets = data
              }
            })
          }
        })
      }
    })
  }

  deleteSet(id: number) {
    this.trainingPlanService.deleteSet(id).subscribe({
      next: data => {
        this.trainingPlanService.getSetsByExerciseId(this.data.exerciseId).subscribe({
          next: data => {
            this.sets = data
          }
        })
      }
    })
  }
  editSet() {
    if (this.editSetForm.value.setRepetitions && this.editSetForm.value.setWeight && this.activeSet) {
      this.trainingPlanService.editSet(this.activeSet.id, {
        repetitions: this.editSetForm.value.setRepetitions,
        weight: this.editSetForm.value.setWeight,
      }).subscribe({
        next: data => {
          this.trainingPlanService.getSetsByExerciseId(this.data.exerciseId).subscribe({
            next: data => {
              this.sets = data
              this.editing.set(false)
            }
          })
        }
      })
    }
  }
  entryEditionMode(set: SetModel) {
    this.activeSet = set
    this.editSetForm.controls.setRepetitions.setValue(set.repetitions)
    this.editSetForm.controls.setWeight.setValue(set.weight)
    this.editing.set(true)
  }
}
