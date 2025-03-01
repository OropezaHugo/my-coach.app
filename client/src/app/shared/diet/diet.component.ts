import {Component, inject, input, OnInit, signal} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {AddFoodToFoodGroupData, FoodGroupFoodCombinedModel, FoodGroupAndContentModel, AddFoodGroupToDietData} from '../../models/diet.models';
import {MatButton, MatIconButton} from '@angular/material/button';
import {RouterLink} from '@angular/router';
import {MatDivider} from '@angular/material/divider';
import { MatDialog } from '@angular/material/dialog';
import {AddFoodDialogComponent} from '../dialogs/add-food-dialog/add-food-dialog.component';
import {MatIcon} from '@angular/material/icon';
import {EditFoodInGroupDialogComponent} from '../dialogs/edit-food-in-group-dialog/edit-food-in-group-dialog.component';
import {AddFoodGroupDialogComponent} from '../dialogs/add-food-group-doalog/add-food-group-dialog.component';
import {EditFoodGroupDialogComponent} from '../dialogs/edit-food-group-doalog/edit-food-group-dialog.component';

@Component({
  selector: 'app-diet',
  imports: [
    MatButton,
    RouterLink,
    MatDivider,
    MatIconButton,
    MatIcon
  ],
  templateUrl: './diet.component.html',
  styleUrl: './diet.component.scss'
})
export class DietComponent implements OnInit {
  dietId = input.required<number>()
  editable = input.required<boolean>();
  hideEdition = signal<boolean>(false);
  dietService = inject(DietService)
  foodGroups: FoodGroupAndContentModel[] = []
  readonly dialog = inject(MatDialog);
  ngOnInit() {
    this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
      next: (data) => {
        this.foodGroups = data
      }
    })
  }

  openAddFoodDialog(addFoodData: AddFoodToFoodGroupData) {
    this.dialog.open(AddFoodDialogComponent, {
      data: addFoodData
    }).afterClosed().subscribe({
      next: (data) => {
        this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
          next: (data) => {
            this.foodGroups = data
          }
        })
      }
    })
  }

  deleteFoodFromFoodGroup(id: number) {
    this.dietService.deleteFoodGroupFoodById(id).subscribe({
      next: (data) => {
        this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
          next: (data) => {
            this.foodGroups = data
          }
        })
      }
    })
  }

  editFoodGroupFood(foodGroupFoodModel: FoodGroupFoodCombinedModel) {
    this.dialog.open(EditFoodInGroupDialogComponent, {
      data: foodGroupFoodModel
    }).afterClosed().subscribe({
      next: (data) => {
        this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
          next: (data) => {
            this.foodGroups = data
          }
        })
      }
    })
  }

  openAddFoodGroupToDietDialog(addFoodGroupData: AddFoodGroupToDietData) {
    this.dialog.open(AddFoodGroupDialogComponent, {
      data: addFoodGroupData
    }).afterClosed().subscribe({
      next: (data) => {
        this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
          next: (data) => {
            this.foodGroups = data
          }
        })
      }
    })
  }

  deleteFoodGroupFromDiet(id: number) {
    this.dietService.deleteFoodGroupFromDietById(id).subscribe({
      next: (data) => {
        this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
          next: (data) => {
            this.foodGroups = data
          }
        })
      }
    })
  }

  editDietFoodGroup(foodGroup: FoodGroupAndContentModel) {
    this.dialog.open(EditFoodGroupDialogComponent, {
      data: foodGroup
    }).afterClosed().subscribe({
      next: (data) => {
        this.dietService.getFoodGroupsByDietId(this.dietId() as number).subscribe({
          next: (data) => {
            this.foodGroups = data
          }
        })
      }
    })
  }
}
