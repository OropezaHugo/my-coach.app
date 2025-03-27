import {Component, inject, input, OnInit} from '@angular/core';
import {AchievementService} from '../../services/achievement.service';
import {UserAchievementModel} from '../../models/achievement.models';
import {UserAchievementsCardComponent} from '../user-achievements-card/user-achievements-card.component';
import {UserBadgesCardComponent} from '../user-badges-card/user-badges-card.component';
import {MatDialog} from '@angular/material/dialog';
import {EditUserBadgesComponent} from '../../shared/dialogs/edit-user-badges/edit-user-badges.component';

@Component({
  selector: 'app-user-badges-panel',
  imports: [
    UserAchievementsCardComponent,
    UserBadgesCardComponent
  ],
  templateUrl: './user-badges-panel.component.html',
  styleUrl: './user-badges-panel.component.scss'
})
export class UserBadgesPanelComponent implements OnInit{
  userId = input.required<number>();
  editable = input.required<boolean>();
  achievementService = inject(AchievementService)
  readonly dialog = inject(MatDialog);
  badges: UserAchievementModel[] = []
  ngOnInit() {
    this.achievementService.getUserBadgesByUserId(this.userId() as number).subscribe({
      next: data => {
        this.badges = data;
      }
    })
  }
  openEditBadgesDialog() {
    this.dialog.open(EditUserBadgesComponent, {
      data: this.userId()
    }).afterClosed().subscribe(result => {
      this.achievementService.getUserBadgesByUserId(this.userId() as number).subscribe({
        next: data => {
          this.badges = data;
        }
      })
    })
  }
}
