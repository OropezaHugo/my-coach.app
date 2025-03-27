import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserModel} from '../../models/user.models';
import {UserProfileComponent} from '../user-profile/user-profile.component';
import {UserDietsPanelComponent} from '../user-diets-panel/user-diets-panel.component';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {UserTrainingPlansPanelComponent} from '../user-training-plans-panel/user-training-plans-panel.component';
import {UserMeasuresPanelComponent} from '../user-measures-panel/user-measures-panel.component';
import {UserPrizesPanelComponent} from '../user-prizes-panel/user-prizes-panel.component';
import {MatDialog} from '@angular/material/dialog';
import {
  EditUserProfileDialogComponent
} from '../../shared/dialogs/edit-user-profile-dialog/edit-user-profile-dialog.component';
import {MatIcon} from '@angular/material/icon';
import {MatIconButton} from '@angular/material/button';
import {UserAchievementsPanelComponent} from '../user-achievements-panel/user-achievements-panel.component';
import {UserBadgesPanelComponent} from '../user-badges-panel/user-badges-panel.component';
import {UserTrainingRecordsComponent} from '../user-training-records/user-training-records.component';

@Component({
  selector: 'app-user-home',
  imports: [
    UserProfileComponent,
    UserDietsPanelComponent,
    MatTabGroup,
    MatTab,
    UserTrainingPlansPanelComponent,
    UserMeasuresPanelComponent,
    UserPrizesPanelComponent,
    MatIcon,
    MatIconButton,
    UserAchievementsPanelComponent,
    UserBadgesPanelComponent,
    UserTrainingRecordsComponent,
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
