import {Component, input} from '@angular/core';
import {UserRoutineRoutineCombined} from '../../models/routine.models';
import {DatePipe} from '@angular/common';
import {MatButton} from '@angular/material/button';
import {RouterLink, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-user-routine-card',
  imports: [
    DatePipe,
    MatButton,
    RouterOutlet,
    RouterLink
  ],
  templateUrl: './user-routine-card.component.html',
  styleUrl: './user-routine-card.component.scss'
})
export class UserRoutineCardComponent {
  routine = input.required<UserRoutineRoutineCombined>();
}
