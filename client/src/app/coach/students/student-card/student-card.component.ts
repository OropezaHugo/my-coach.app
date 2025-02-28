import {Component, input} from '@angular/core';
import {UserModel} from '../../../models/user.models';
import {MatCard, MatCardActions, MatCardHeader, MatCardSubtitle, MatCardTitle} from '@angular/material/card';
import {MatButton} from '@angular/material/button';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'app-student-card',
  imports: [
    MatCardSubtitle,
    MatCardTitle,
    MatButton,
    MatCardHeader,
    MatCardActions,
    MatCard,
    RouterLink
  ],
  templateUrl: './student-card.component.html',
  styleUrl: './student-card.component.scss'
})
export class StudentCardComponent {
  student = input.required<UserModel>()
}
