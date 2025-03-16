import {Component, inject, input, OnInit, signal} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {
  AddFoodToFoodGroupData,
  FoodGroupFoodCombinedModel,
  FoodGroupAndContentModel,
  AddFoodGroupToDietData,
  DietContent
} from '../../models/diet.models';
import {MatButton, MatIconButton} from '@angular/material/button';
import {RouterLink} from '@angular/router';
import {MatDivider} from '@angular/material/divider';
import { MatDialog } from '@angular/material/dialog';
import {AddFoodDialogComponent} from '../dialogs/add-food-dialog/add-food-dialog.component';
import {MatIcon} from '@angular/material/icon';
import {EditFoodInGroupDialogComponent} from '../dialogs/edit-food-in-group-dialog/edit-food-in-group-dialog.component';
import {AddFoodGroupDialogComponent} from '../dialogs/add-food-group-doalog/add-food-group-dialog.component';
import {EditFoodGroupDialogComponent} from '../dialogs/edit-food-group-doalog/edit-food-group-dialog.component';
import {
  MatCell, MatCellDef, MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow,
  MatRowDef, MatTable
} from '@angular/material/table';
import {DecimalPipe} from '@angular/common';
import {MatMenu, MatMenuItem, MatMenuTrigger} from '@angular/material/menu';

@Component({
  selector: 'app-diet',
  imports: [
    MatButton,
    RouterLink,
    MatDivider,
    MatIconButton,
    MatIcon,
    MatRow,
    MatRowDef,
    MatHeaderRowDef,
    MatHeaderRow,
    MatHeaderCellDef,
    MatHeaderCell,
    MatCell,
    MatColumnDef,
    MatCellDef,
    MatTable,
    DecimalPipe,
    MatMenuTrigger,
    MatMenuItem,
    MatMenu
  ],
  templateUrl: './diet.component.html',
  styleUrl: './diet.component.scss'
})
export class DietComponent implements OnInit {
  dietId = input.required<number>()
  editable = input.required<boolean>();
  hideEdition = signal<boolean>(false);
  dietService = inject(DietService)
  dietContent?: DietContent = undefined
  readonly dialog = inject(MatDialog);
  columns: string[] = []
  advancedView = signal<boolean>(false);
  toMinutes = (time: string): number => {
    const [hours, minutes] = time.split(':').map(Number);
    return hours * 60 + minutes;
  };
  ngOnInit() {
    this.dietService.getDietContentById(this.dietId() as number).subscribe({
      next: (data) => {
        data.dietFoodGroupInfos.sort((a, b) => {
          return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
        });
        this.dietContent = data
        this.columns = this.editable() ? ['foodName', 'foodAmount', 'foodEnergyKcal', 'foodProteinGr', 'foodFatGr', 'foodCarbsGr', 'foodFibberGr', 'foodAshGr', 'foodCalciumGr', 'foodPhosphorusMg', 'foodVitaminAMig', 'foodIronMg', 'foodVitaminB1Mg', 'foodVitaminB2Mg', 'foodVitaminB3Mg', 'foodVitaminCMg', 'actions'] : ['foodName', 'foodAmount', 'foodEnergyKcal', 'foodProteinGr', 'foodFatGr', 'foodCarbsGr', 'foodFibberGr', 'foodAshGr', 'foodCalciumGr', 'foodPhosphorusMg', 'foodVitaminAMig', 'foodIronMg', 'foodVitaminB1Mg', 'foodVitaminB2Mg', 'foodVitaminB3Mg', 'foodVitaminCMg']
      }
    })
  }

  openAddFoodDialog(addFoodData: AddFoodToFoodGroupData) {
    this.dialog.open(AddFoodDialogComponent, {
      data: addFoodData,
      minWidth: '100%',
    }).afterClosed().subscribe({
      next: (data) => {
        this.dietService.getDietContentById(this.dietId() as number).subscribe({
          next: (data) => {
            data.dietFoodGroupInfos.sort((a, b) => {
              return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
            });
            this.dietContent = data
          }
        })
      }
    })
  }

  deleteFoodFromFoodGroup(id: number) {
    this.dietService.deleteFoodGroupFoodById(id).subscribe({
      next: (data) => {
        this.dietService.getDietContentById(this.dietId() as number).subscribe({
          next: (data) => {
            data.dietFoodGroupInfos.sort((a, b) => {
              return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
            });
            this.dietContent = data
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
        this.dietService.getDietContentById(this.dietId() as number).subscribe({
          next: (data) => {
            data.dietFoodGroupInfos.sort((a, b) => {
              return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
            });
            this.dietContent = data
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
        this.dietService.getDietContentById(this.dietId() as number).subscribe({
          next: (data) => {
            data.dietFoodGroupInfos.sort((a, b) => {
              return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
            });
            this.dietContent = data
          }
        })
      }
    })
  }

  deleteFoodGroupFromDiet(id: number) {
    this.dietService.deleteFoodGroupFromDietById(id).subscribe({
      next: (data) => {
        this.dietService.getDietContentById(this.dietId() as number).subscribe({
          next: (data) => {
            data.dietFoodGroupInfos.sort((a, b) => {
              return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
            });
            this.dietContent = data
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
        this.dietService.getDietContentById(this.dietId() as number).subscribe({
          next: (data) => {
            data.dietFoodGroupInfos.sort((a, b) => {
              return this.toMinutes(a.foodGroupTime) - this.toMinutes(b.foodGroupTime);
            });
            this.dietContent = data
          }
        })
      }
    })
  }

  toggleHideEdition() {
    this.hideEdition.set(!this.hideEdition())
    if (this.hideEdition()) {
      this.columns = this.columns.filter(c => c != 'actions')
    } else {
      this.columns.push('actions')
    }
  }
}
