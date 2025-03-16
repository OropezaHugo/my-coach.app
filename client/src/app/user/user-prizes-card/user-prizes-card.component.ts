import {Component, inject, input, OnInit, output} from '@angular/core';
import {PrizeModel} from '../../models/prize.models';
import {MatCard, MatCardActions, MatCardHeader, MatCardSubtitle, MatCardTitle} from '@angular/material/card';
import {MatButton} from '@angular/material/button';
import {NgOptimizedImage} from '@angular/common';
import {PrizesService} from '../../services/prizes.service';
import {MatDialog} from '@angular/material/dialog';
import {RewardUserDialogComponent} from '../../shared/dialogs/reward-user-dialog/reward-user-dialog.component';

@Component({
  selector: 'app-user-prize-card',
  imports: [
    MatCardTitle,
    MatCardSubtitle,
    MatCardActions,
    MatCardHeader,
    MatCard,
    MatButton,
    NgOptimizedImage
  ],
  templateUrl: './user-prizes-card.component.html',
  styleUrl: './user-prizes-card.component.scss'
})
export class UserPrizesCardComponent implements OnInit{
  prize = input.required<PrizeModel>()
  editable = input<boolean>(false)
  dialog = inject(MatDialog)
  prizeId = output<number>()
  imageUrl = '/prize1'
  rewardUser() {
    this.prizeId.emit(this.prize().id)
  }
  ngOnInit() {
    this.imageUrl = `data:image/png;base64,${this.prize().prizeImage}`;
  }
}
