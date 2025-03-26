import {Component, inject, input, OnInit} from '@angular/core';
import {TrainingRecordService} from '../../services/training-record.service';
import {
  AddRecordDialogDada,
  ExerciseBasicData,
  TrainingRecordContent,
  TrainingRecordModel
} from '../../models/training-records.models';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {UserTrainingRecordsTabComponent} from '../user-training-recods-tab/user-training-records-tab.component';
import {MatButton} from '@angular/material/button';
import {MatDialog} from '@angular/material/dialog';
import {AddRecordDialogComponent} from '../../shared/dialogs/add-record-dialog/add-record-dialog.component';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {FormControl, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-user-training-recods-panel',
  imports: [
    MatTabGroup,
    MatTab,
    UserTrainingRecordsTabComponent,
    MatButton,
    MatLabel,
    MatFormField,
    MatSelect,
    ReactiveFormsModule,
    MatOption
  ],
  templateUrl: './user-training-records-panel.component.html',
  styleUrl: './user-training-records-panel.component.scss'
})
export class UserTrainingRecordsPanelComponent implements OnInit {
  trainingRecordService = inject(TrainingRecordService)
  userId = input.required<number>()
  editable = input.required<boolean>();
  exerciseBasicData: ExerciseBasicData[] = []
  exerciseForm = new FormControl<number[]>([], Validators.required);
  dialog = inject(MatDialog)
  ngOnInit() {
    this.trainingRecordService.getTrainingRecordExercisesBasicDataByUserId(this.userId() as number).subscribe({
      next: (data) => {
        this.exerciseBasicData = data;
      }
    })
  }

  openAddRecordDialog(data: AddRecordDialogDada) {
    this.dialog.open(AddRecordDialogComponent, {
      data: data,
    }).afterClosed().subscribe({
      next: () => {
        this.trainingRecordService.getTrainingRecordExercisesBasicDataByUserId(this.userId() as number).subscribe({
          next: (data) => {
            this.exerciseBasicData = data;
          }
        })
      }
    })
  }
}
