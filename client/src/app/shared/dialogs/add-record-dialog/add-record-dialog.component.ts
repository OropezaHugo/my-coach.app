import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddDietDataToUserDiets} from '../../../models/diet.models';
import {AddRecordDialogDada, ExerciseBasicData} from '../../../models/training-records.models';
import {TrainingRecordService} from '../../../services/training-record.service';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatAutocomplete, MatAutocompleteTrigger, MatOption} from '@angular/material/autocomplete';
import {MatButton} from '@angular/material/button';
import {MatSelect} from '@angular/material/select';

@Component({
  selector: 'app-add-record-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatAutocomplete,
    MatOption,
    MatAutocompleteTrigger,
    MatButton,
    MatSelect
  ],
  templateUrl: './add-record-dialog.component.html',
  styleUrl: './add-record-dialog.component.scss'
})
export class AddRecordDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<AddRecordDialogComponent>);
  data = inject<AddRecordDialogDada>(MAT_DIALOG_DATA);
  trainingRecordService = inject(TrainingRecordService)
  exercisesBasicData: ExerciseBasicData[] = [];
  addRecordForm = new FormGroup({
    repetitions: new FormControl<number>(1, [Validators.required, Validators.min(1)]),
    weight: new FormControl<number>(0, [Validators.required, Validators.min(0)]),
    exerciseId: new FormControl<number>(1, [Validators.required]),
    exerciseName: new FormControl<string>('', [Validators.required]),
  })

  setExercise(exercise: ExerciseBasicData) {
    this.addRecordForm.controls.exerciseId.setValue(exercise.id)
  }
  ngOnInit() {
    this.trainingRecordService.getExercisesBasicData().subscribe({
      next: result => {
        this.exercisesBasicData = result;
      }
    })
  }

  createRecord() {
    if (this.addRecordForm.value.weight && this.addRecordForm.value.exerciseId && this.addRecordForm.value.repetitions) {
      this.trainingRecordService.createTrainingRecord({
        recordDate:  new Date().toISOString().split('T')[0],
        exerciseId: this.addRecordForm.value.exerciseId,
        userId: this.data.userId,
        repetitionsMade: this.addRecordForm.value.repetitions,
        weightLifted: this.addRecordForm.value.weight,
      }).subscribe({
        next: result => {
          this.dialogRef.close();
        }
      })
    }
  }
}
