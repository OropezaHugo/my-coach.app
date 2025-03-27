import {Component, inject, input, numberAttribute, OnInit} from '@angular/core';
import {UserService} from '../../../services/user.service';
import {UserModel} from '../../../models/user.models';
import {UserDietsPanelComponent} from '../../../user/user-diets-panel/user-diets-panel.component';
import {UserProfileComponent} from '../../../user/user-profile/user-profile.component';
import {MatButton} from '@angular/material/button';
import {RouterLink} from '@angular/router';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {UserTrainingPlansPanelComponent} from '../../../user/user-training-plans-panel/user-training-plans-panel.component';

import {UserMeasuresPanelComponent} from "../../../user/user-measures-panel/user-measures-panel.component";
import {UserPrizesPanelComponent} from '../../../user/user-prizes-panel/user-prizes-panel.component';
import {UserAchievementsPanelComponent} from "../../../user/user-achievements-panel/user-achievements-panel.component";
import {UserBadgesPanelComponent} from "../../../user/user-badges-panel/user-badges-panel.component";
import {
  UserTrainingRecordsComponent
} from '../../../user/user-training-records/user-training-records.component';

@Component({
  selector: 'app-student-profile',
  imports: [
    UserDietsPanelComponent,
    UserProfileComponent,
    MatButton,
    RouterLink,
    MatTabGroup,
    MatTab,
    UserTrainingPlansPanelComponent,
    UserMeasuresPanelComponent,
    UserPrizesPanelComponent,
    UserAchievementsPanelComponent,
    UserBadgesPanelComponent,
    UserTrainingRecordsComponent,
  ],
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.scss'
})
export class StudentProfileComponent implements OnInit {
  userId = input.required<number>()
  user?: UserModel = undefined
  userService = inject(UserService)
  ngOnInit() {
    this.userService.getUserById(this.userId() as number).subscribe({
      next: data => {
        this.user = data
      }
    })
  }
}
