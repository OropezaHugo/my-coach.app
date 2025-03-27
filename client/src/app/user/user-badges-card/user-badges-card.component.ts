import {Component, input} from '@angular/core';
import {LEVEL_COLORS, UserAchievementModel} from '../../models/achievement.models';
import {MatCard, MatCardContent, MatCardHeader, MatCardSubtitle, MatCardTitle} from '@angular/material/card';
import {MatProgressBar} from '@angular/material/progress-bar';

@Component({
  selector: 'app-user-badges-card',
  imports: [
    MatCard,
    MatCardContent,
    MatCardHeader,
    MatCardSubtitle,
    MatCardTitle,
    MatProgressBar
  ],
  templateUrl: './user-badges-card.component.html',
  styleUrl: './user-badges-card.component.scss'
})
export class UserBadgesCardComponent {
  badge = input.required<UserAchievementModel>()

  protected readonly LEVEL_COLORS = LEVEL_COLORS;
}
