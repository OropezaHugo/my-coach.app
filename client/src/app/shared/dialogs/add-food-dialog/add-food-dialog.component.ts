import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodData, FoodModel} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {MatButton} from '@angular/material/button';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-add-food-dialog',
  imports: [
    MatButton,
    MatDialogContent,
    MatFormField,
    MatSelect,
    MatOption,
    ReactiveFormsModule,
    MatInput,
    MatLabel
  ],
  templateUrl: './add-food-dialog.component.html',
  styleUrl: './add-food-dialog.component.scss'
})
export class AddFoodDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<AddFoodDialogComponent>);
  data = inject<AddFoodData>(MAT_DIALOG_DATA);
  dietService = inject(DietService)
  addFoodForm = new FormGroup({
    foodId: new FormControl<number | null>(null, [Validators.required]),
    foodAmount: new FormControl<number | null>(null, [Validators.required]),
  })
  foods: FoodModel[] = []
  ngOnInit() {
    this.dietService.getAllFoods().subscribe({
      next: data => {
        this.foods = data;
      }
    })
  }

  addFoodToFoodGroup() {
    if (this.addFoodForm.value.foodId && this.addFoodForm.value.foodAmount) {
      this.dietService.addFoodToFoodGroup({
        foodId: this.addFoodForm.value.foodId,
        foodGroupId: this.data.foodGroupId,
        foodAmount: this.addFoodForm.value.foodAmount
      }).subscribe({
        next: data => {
          this.dialogRef.close()
        }
      })
    }
  }
}
