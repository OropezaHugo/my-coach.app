import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodToFoodGroupData, FoodModel} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {MatButton} from '@angular/material/button';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {MatInput} from '@angular/material/input';
import {FoodComponent} from '../../food/food.component';

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
    MatLabel,
    FoodComponent
  ],
  templateUrl: './add-food-dialog.component.html',
  styleUrl: './add-food-dialog.component.scss'
})
export class AddFoodDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<AddFoodDialogComponent>);
  data = inject<AddFoodToFoodGroupData>(MAT_DIALOG_DATA);
  dietService = inject(DietService)
  addFoodForm = new FormGroup({
    food: new FormControl<FoodModel | null>(null, [Validators.required]),
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
    if (this.addFoodForm.value.food && this.addFoodForm.value.foodAmount) {
      this.dietService.addFoodToFoodGroup({
        foodId: this.addFoodForm.value.food.id,
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
