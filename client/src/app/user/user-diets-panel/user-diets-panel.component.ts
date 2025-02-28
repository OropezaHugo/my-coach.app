import {Component, inject, input, OnInit} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {UserDiet} from '../../models/diet.models';
import {UserDietCardComponent} from '../user-diet-card/user-diet-card.component';

@Component({
  selector: 'app-user-diets-panel',
  imports: [
    UserDietCardComponent
  ],
  templateUrl: './user-diets-panel.component.html',
  styleUrl: './user-diets-panel.component.scss'
})
export class UserDietsPanelComponent implements OnInit {
  userId = input.required<number>();
  dietService = inject(DietService)
  diets: UserDiet[] = []

  ngOnInit() {
    this.dietService.getDietsByUserId(this.userId()).subscribe({
      next: data => {
        this.diets = data
      }
    })
  }
}
