import {Component, input} from '@angular/core';
import {UserDiet} from '../../models/diet.models';
import {DatePipe} from '@angular/common';
import {
  MatExpansionPanel,
  MatExpansionPanelDescription,
  MatExpansionPanelHeader,
  MatExpansionPanelTitle
} from '@angular/material/expansion';
import {DietComponent} from '../../shared/diet/diet.component';
import {MatButton} from '@angular/material/button';
import {RouterLink, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-user-diet-card',
  imports: [
    DatePipe,
    MatExpansionPanel,
    MatExpansionPanelHeader,
    MatExpansionPanelTitle,
    MatExpansionPanelDescription,
    DietComponent,
    MatButton,
    RouterLink,
    RouterOutlet
  ],
  templateUrl: './user-diet-card.component.html',
  styleUrl: './user-diet-card.component.scss'
})
export class UserDietCardComponent {
  diet = input.required<UserDiet>()
}
