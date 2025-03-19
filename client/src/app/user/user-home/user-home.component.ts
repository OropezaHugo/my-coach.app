import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserModel} from '../../models/user.models';
import {UserProfileComponent} from '../user-profile/user-profile.component';
import {UserDietsPanelComponent} from '../user-diets-panel/user-diets-panel.component';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {UserTrainingPlansPanelComponent} from '../user-training-plans-panel/user-training-plans-panel.component';
import {UserTrainingRecordsPanelComponent} from '../user-training-recods-panel/user-training-records-panel.component';
import {UserMeasuresPanelComponent} from '../user-measures-panel/user-measures-panel.component';
import {UserPrizesPanelComponent} from '../user-prizes-panel/user-prizes-panel.component';
import {MatDialog} from '@angular/material/dialog';
import {
  EditUserProfileDialogComponent
} from '../../shared/dialogs/edit-user-profile-dialog/edit-user-profile-dialog.component';
import {MatIcon} from '@angular/material/icon';
import {MatIconButton} from '@angular/material/button';

@Component({
  selector: 'app-user-home',
  imports: [
    UserProfileComponent,
    UserDietsPanelComponent,
    MatTabGroup,
    MatTab,
    UserTrainingPlansPanelComponent,
    UserTrainingRecordsPanelComponent,
    UserMeasuresPanelComponent,
    UserPrizesPanelComponent,
    MatIcon,
    MatIconButton,
  ],
  templateUrl: './user-home.component.html',
  styleUrl: './user-home.component.scss'
})
export class UserHomeComponent implements OnInit {

  user: UserModel | undefined = undefined
  userService = inject(UserService)
  dialog = inject(MatDialog)
  openEditProfileDataDialog() {
      this.dialog.open(EditUserProfileDialogComponent, {
        data: this.user
      }).afterClosed().subscribe({
        next: data => {
          if (this.user) {
            this.userService.getActualUserInfo(this.user.email).subscribe({
              next: data => {
                this.user = this.userService.userData()
              }
            })
          }
        }
      })
  }
  ngOnInit() {
    this.user = this.userService.userData()
  }
}
