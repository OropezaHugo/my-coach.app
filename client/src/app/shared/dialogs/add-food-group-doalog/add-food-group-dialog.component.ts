import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodData, AddFoodGroupData, FoodGroupData} from '../../../models/diet.models';
import {DietService} from '../../../services/diet.service';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton} from '@angular/material/button';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {MatAutocomplete, MatAutocompleteTrigger, MatOption} from '@angular/material/autocomplete';

@Component({
  selector: 'app-add-food-group-doalog',
  imports: [
    MatDialogContent,
    MatFormField,
    MatInput,
    MatLabel,
    ReactiveFormsModule,
    MatButton,
    MatTabGroup,
    MatTab,
    MatAutocomplete,
    MatOption,
    MatAutocompleteTrigger
  ],
  templateUrl: './add-food-group-dialog.component.html',
  styleUrl: './add-food-group-dialog.component.scss'
})
export class AddFoodGroupDialogComponent implements OnInit{
  dialogRef = inject(MatDialogRef<AddFoodGroupDialogComponent>);
  data = inject<AddFoodGroupData>(MAT_DIALOG_DATA);
  dietService = inject(DietService)
  addFoodGroupForm = new FormGroup({
    foodGroupName: new FormControl<string>('', Validators.required),
    foodGroupTime: new FormControl<string>('hh:mm', [Validators.required, Validators.pattern('^(?:[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$')]),
  })
  foodGroupsNames: string[] = [];
  ngOnInit() {
    this.dietService.getFoodGroupNames().subscribe({
      next: data => {
        this.foodGroupsNames = data;
      }
    })
  }

  addFoodGroupToDiet() {
    if (this.addFoodGroupForm.value.foodGroupName && this.addFoodGroupForm.value.foodGroupTime && this.addFoodGroupForm.valid) {
      this.dietService.createFoodGroup({
        foodGroupName: this.addFoodGroupForm.value.foodGroupName
      }).subscribe({
        next: (foodGroup: FoodGroupData) => {
          if (this.addFoodGroupForm.value.foodGroupTime) {
            this.dietService.addFoodGroupToDiet({
              dietId: this.data.dietId,
              foodGroupTime: this.addFoodGroupForm.value.foodGroupTime,
              foodGroupId: foodGroup.id
            }).subscribe({
              next: (res) => {
                this.dialogRef.close()
              }
            })
          }

        }
      })
    }

  }
}
