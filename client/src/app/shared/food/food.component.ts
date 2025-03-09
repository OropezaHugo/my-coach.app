import {AfterViewInit, Component, inject, OnInit, output, viewChild} from '@angular/core';
import {DecimalPipe} from "@angular/common";
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow,
  MatHeaderRowDef,
  MatNoDataRow,
  MatRow,
  MatRowDef,
  MatTable,
  MatTableDataSource
} from "@angular/material/table";
import {DietService} from '../../services/diet.service';
import {FoodFilterOptions, FoodModel} from '../../models/diet.models';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort, MatSortHeader} from '@angular/material/sort';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatOptgroup, MatOption, MatSelect} from '@angular/material/select';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';

@Component({
  selector: 'app-food',
  imports: [
    DecimalPipe,
    MatCell,
    MatCellDef,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderRow,
    MatHeaderRowDef,
    MatRow,
    MatRowDef,
    MatTable,
    MatHeaderCellDef,
    MatPaginator,
    MatSort,
    MatSortHeader,
    MatLabel,
    MatInput,
    MatFormField,
    MatNoDataRow,
    MatSelect,
    ReactiveFormsModule,
    MatOptgroup,
    MatOption,
  ],
  templateUrl: './food.component.html',
  styleUrl: './food.component.scss'
})
export class FoodComponent implements OnInit, AfterViewInit{
  selectedFood = output<FoodModel>()
  columns: string[] = ['foodName', 'foodGroup', 'foodSubGroup', 'foodEnergyKcal', 'foodProteinGr', 'foodFatGr', 'foodCarbsGr', 'foodFibberGr', 'foodAshGr', 'foodCalciumGr', 'foodPhosphorusMg', 'foodVitaminAMig', 'foodIronMg', 'foodVitaminB1Mg', 'foodVitaminB2Mg', 'foodVitaminB3Mg', 'foodVitaminCMg']
  dietService = inject(DietService)
  foods: FoodModel[] = []
  filterOptions: FoodFilterOptions[] = []
  foodFiltersForm = new FormGroup({
    foodSubGroup:  new FormControl<string>(''),
    foodName: new FormControl('')
  })
  dataSource:MatTableDataSource<FoodModel> = new MatTableDataSource()
  paginator = viewChild.required<MatPaginator>(MatPaginator)
  sort = viewChild.required<MatSort>(MatSort)
  ngOnInit() {
    this.dietService.getAllFoods().subscribe({
      next: (data) => {
        this.foods = data
        this.dataSource = new MatTableDataSource<FoodModel>(data)
      }
    })
    this.dietService.getFoodFilterOptions().subscribe({
      next: (data) => {
        this.filterOptions = data
      }
    })
  }
  ngAfterViewInit() {
    this.dietService.getAllFoods().subscribe({
      next: (data) => {
        this.foods = data
        this.dataSource = new MatTableDataSource<FoodModel>(data)

        this.dataSource.paginator = this.paginator()
        this.dataSource.sort = this.sort()

      }
    })
  }
  applyFiltering() {
    let filterValue = this.foodFiltersForm.value.foodName ?? ''
    if (this.foodFiltersForm.value.foodSubGroup) {
      filterValue = filterValue.trim().toLowerCase();
      filterValue += '+' + this.foodFiltersForm.value.foodSubGroup
      this.dataSource.filterPredicate = (food, filterString) => food.foodName.trim().toLowerCase().includes(filterString.split('+')[0]) && food.foodSubGroup == filterString.split('+')[1]
      this.dataSource.filter = filterValue
    } else {
      this.dataSource.filterPredicate = (food, filterString) => food.foodName.trim().toLowerCase().includes(filterString)
      this.dataSource.filter = filterValue.trim().toLowerCase();
    }
  }
}
