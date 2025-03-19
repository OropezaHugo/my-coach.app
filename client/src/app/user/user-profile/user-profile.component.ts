import {Component, inject, input} from '@angular/core';
import {UserModel} from '../../models/user.models';
import {DatePipe} from '@angular/common';

@Component({
  selector: 'app-user-profile',
  imports: [
    DatePipe
  ],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent {
  user = input.required<UserModel>()
}
