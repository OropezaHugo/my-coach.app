import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodToFoodGroupData, FoodGroupFoodData, FoodGroupFoodCombinedModel, FoodModel} from '../../../models/diet.models';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, ReactiveFormsModule, Validators} from '@angular/forms';
import {DietService} from '../../../services/diet.service';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-edit-food-in-group-dialog',
  imports: [
    MatFormField,
    MatInput,
    MatLabel,
    ReactiveFormsModule,
    MatButton,
    MatDialogContent
  ],
  templateUrl: './edit-food-in-group-dialog.component.html',
  styleUrl: './edit-food-in-group-dialog.component.scss'
})
export class EditFoodInGroupDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<EditFoodInGroupDialogComponent>);
  data = inject<FoodGroupFoodCombinedModel>(MAT_DIALOG_DATA);
  dietService = inject(DietService)
  food?: FoodModel = undefined
  foodAmountControl = new FormControl<number>(this.data.foodAmount, [Validators.required]);
  ngOnInit() {
    this.dietService.getFoodById(this.data.foodId).subscribe({
      next: data => {
        this.food = data;
      }
    })
  }
  updateFoodGroupFoodData() {
    if (this.foodAmountControl.value) {
      this.dietService.updateFoodGroupFoodById(this.data.id, {
        foodGroupId: this.data.foodGroupId,
        foodId: this.data.foodId,
        foodAmount: this.foodAmountControl.value
      }).subscribe({
        next: data => {
          this.dialogRef.close();
        }
      })
    }
  }
}
