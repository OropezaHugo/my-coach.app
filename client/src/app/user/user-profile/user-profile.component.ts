import {Component, inject, input} from '@angular/core';
import {UserModel} from '../../models/user.models';
import {DatePipe} from '@angular/common';
import {UserBadgesPanelComponent} from '../user-badges-panel/user-badges-panel.component';
import {MatDialog} from '@angular/material/dialog';
import {EditUserBadgesComponent} from '../../shared/dialogs/edit-user-badges/edit-user-badges.component';

@Component({
  selector: 'app-user-profile',
  imports: [
    DatePipe,
    UserBadgesPanelComponent
  ],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent {
  user = input.required<UserModel>()
}
