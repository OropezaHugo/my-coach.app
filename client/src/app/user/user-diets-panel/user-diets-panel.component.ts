import {Component, inject, input, OnInit} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {AddDietData, UserDietCombined} from '../../models/diet.models';
import {UserDietCardComponent} from '../user-diet-card/user-diet-card.component';
import {MatButton} from '@angular/material/button';
import {MatDialog} from '@angular/material/dialog';
import {AddDietDialogComponent} from '../../shared/dialogs/add-diet-dialog/add-diet-dialog.component';

@Component({
  selector: 'app-user-diets-panel',
  imports: [
    UserDietCardComponent,
    MatButton
  ],
  templateUrl: './user-diets-panel.component.html',
  styleUrl: './user-diets-panel.component.scss'
})
export class UserDietsPanelComponent implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  dietService = inject(DietService)
  diets: UserDietCombined[] = []
  dialog = inject(MatDialog)
  ngOnInit() {
    this.dietService.getDietsByUserId(this.userId()).subscribe({
      next: data => {
        this.diets = data
      }
    })
  }

  openAddDietToUserDialog(addDietData : AddDietData) {
    this.dialog.open(AddDietDialogComponent, {
      data: addDietData
    }).afterClosed().subscribe({
      next: data => {
        this.dietService.getDietsByUserId(this.userId()).subscribe({
          next: data => {
            this.diets = data
          }
        })
      }
    })
  }
}
