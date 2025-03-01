import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {
  AddFoodGroupData,
  DietFoodGroupData,
  FoodGroupAndContentModel,
  FoodGroupData
} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {FormControl, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-edit-food-group-doalog',
  imports: [
    MatDialogContent,
    MatFormField,
    MatInput,
    MatLabel,
    ReactiveFormsModule,
    MatButton
  ],
  templateUrl: './edit-food-group-dialog.component.html',
  styleUrl: './edit-food-group-dialog.component.scss'
})
export class EditFoodGroupDialogComponent {
  dialogRef = inject(MatDialogRef<EditFoodGroupDialogComponent>);
  data = inject<FoodGroupAndContentModel>(MAT_DIALOG_DATA);
  dietService = inject(DietService)
  foodGroupTime = new FormControl<string>('hh:mm', [Validators.required, Validators.pattern('^(?:[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$')])
  editFoodGroup(){
    if (this.foodGroupTime.value && this.foodGroupTime.valid) {
      this.dietService.updateDietFoodGroupById(this.data.id, {
        foodGroupId: this.data.foodGroupId,
        dietId: this.data.dietId,
        foodGroupTime: this.foodGroupTime.value
      }).subscribe({
        next: (data) => {
          this.dialogRef.close()
        }
      })
    }
  }
}
