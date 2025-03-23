import {Component, input} from '@angular/core';
import {LEVEL_COLORS, UserAchievementModel} from '../../models/achievement.models';
import {MatCard, MatCardContent, MatCardHeader, MatCardSubtitle, MatCardTitle} from '@angular/material/card';
import {MatProgressBar} from '@angular/material/progress-bar';

@Component({
  selector: 'app-user-achievements-card',
  imports: [
    MatCardSubtitle,
    MatCardTitle,
    MatCardHeader,
    MatCardContent,
    MatProgressBar,
    MatCard
  ],
  templateUrl: './user-achievements-card.component.html',
  styleUrl: './user-achievements-card.component.scss'
})
export class UserAchievementsCardComponent {
  achievement = input.required<UserAchievementModel>()

  protected readonly LEVEL_COLORS = LEVEL_COLORS;
}
