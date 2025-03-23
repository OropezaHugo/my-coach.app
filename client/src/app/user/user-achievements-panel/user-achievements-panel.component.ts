import {Component, inject, input, OnInit} from '@angular/core';
import {AchievementService} from '../../services/achievement.service';
import {UserAchievementModel} from '../../models/achievement.models';
import {UserAchievementsCardComponent} from '../user-achievements-card/user-achievements-card.component';

@Component({
  selector: 'app-user-achievements-panel',
  imports: [
    UserAchievementsCardComponent
  ],
  templateUrl: './user-achievements-panel.component.html',
  styleUrl: './user-achievements-panel.component.scss'
})
export class UserAchievementsPanelComponent implements OnInit {
  userId = input.required<number>();
  achievementService = inject(AchievementService)
  achievements: UserAchievementModel[] = []
  ngOnInit() {
    this.achievementService.getUserAchievementsDataByUserId(this.userId() as number).subscribe({
      next: data => {
        this.achievements = data;
      }
    })
  }
}
