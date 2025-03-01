import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddDietData, AddFoodData, DietData} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {MatAutocomplete, MatAutocompleteTrigger, MatOption} from '@angular/material/autocomplete';
import {MatButton} from '@angular/material/button';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {UserService} from '../../../services/user.service';

@Component({
  selector: 'app-add-diet-dialog',
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
  templateUrl: './add-diet-dialog.component.html',
  styleUrl: './add-diet-dialog.component.scss'
})
export class AddDietDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<AddDietDialogComponent>);
  data = inject<AddDietData>(MAT_DIALOG_DATA);
  dietService = inject(DietService)
  addDietForm = new FormGroup({
    dietName: new FormControl<string>('', [Validators.required]),
    waterAmount: new FormControl<number>(1, [Validators.required]),
  })
  dietsNames: string[] = []
  ngOnInit() {
    this.dietService.getDietNames().subscribe({
      next: data => {
        this.dietsNames = data;
      }
    })
  }

  addDietToUser() {
    if (this.addDietForm.value.dietName && this.addDietForm.value.waterAmount && this.addDietForm.valid) {
      this.dietService.createDiet({
        dietName: this.addDietForm.value.dietName,
        waterAmount: this.addDietForm.value.waterAmount,
      }).subscribe({
        next: diet => {
          if (this.addDietForm.value.waterAmount) {
            this.dietService.addDietToUserDiets({
              dietId: diet.id,
              userId: this.data.userId,
              assignedDate: new Date().toISOString().split('T')[0],
            }).subscribe({
              next: data => {
                this.dialogRef.close();
              }
            })
          }
        }
      })
    }

  }
}
