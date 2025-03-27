import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {UserModel} from '../../../models/user.models';
import {UserService} from '../../../services/user.service';
import {AchievementService} from '../../../services/achievement.service';
import {LEVEL_COLORS, UserAchievementModel} from '../../../models/achievement.models';
import {MatCard, MatCardHeader, MatCardSubtitle, MatCardTitle} from '@angular/material/card';

@Component({
  selector: 'app-edit-user-badges',
  imports: [
    MatDialogContent,
    MatCard,
    MatCardHeader,
    MatCardTitle,
    MatCardSubtitle
  ],
  templateUrl: './edit-user-badges.component.html',
  styleUrl: './edit-user-badges.component.scss'
})
export class EditUserBadgesComponent implements OnInit {
  dialogRef = inject(MatDialogRef<EditUserBadgesComponent>);
  data = inject<number>(MAT_DIALOG_DATA);
  achievements: UserAchievementModel[] = []
  achievementsService = inject(AchievementService)
  ngOnInit() {
    this.achievementsService.getUserAchievementsDataByUserId(this.data).subscribe({
      next: data => {
        this.achievements = data;
      }
    })
  }

  protected readonly LEVEL_COLORS = LEVEL_COLORS;

  changeBadgeState(achievement: UserAchievementModel) {
    this.achievementsService.updateUserBadge(achievement.id, {
      isBadge: !achievement.isBadge,
    }).subscribe({
      next: data => {
        this.achievementsService.getUserAchievementsDataByUserId(this.data).subscribe({
          next: data => {
            this.achievements = data;
          }
        })
      }
    })
  }
}
