import {Component, inject, input, OnInit} from '@angular/core';
import {PrizesService} from '../../services/prizes.service';
import {PrizeModel, RewardUserDialogData, UserPrizeInfoModel} from '../../models/prize.models';
import {UserPrizesCardComponent} from '../user-prizes-card/user-prizes-card.component';
import {MatButton, MatIconButton} from '@angular/material/button';
import {MatDialog} from '@angular/material/dialog';
import {RewardUserDialogComponent} from '../../shared/dialogs/reward-user-dialog/reward-user-dialog.component';
import {MatIcon} from '@angular/material/icon';

@Component({
  selector: 'app-user-prize-panel',
  imports: [
    UserPrizesCardComponent,
    MatButton,
    MatIconButton,
    MatIcon

  ],
  templateUrl: './user-prizes-panel.component.html',
  styleUrl: './user-prizes-panel.component.scss'
})
export class UserPrizesPanelComponent implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  prizeService = inject(PrizesService)
  prizes: UserPrizeInfoModel[] = []
  dialog = inject(MatDialog);

  ngOnInit() {
    this.prizeService.getPrizesByUserId(this.userId() as number).subscribe({
      next: data => {
        this.prizes = data;
      }
    })
  }

  addPrizeToUser(data: RewardUserDialogData) {
    this.dialog.open(RewardUserDialogComponent, {
      data: data
    }).afterClosed().subscribe({
      next: data => {
        this.prizeService.getPrizesByUserId(this.userId() as number).subscribe({
          next: prizes => {
            this.prizes = prizes;
          }
        })
      }
    })
  }

  deletePrizeFromUser(userPrizeId: number) {
    this.prizeService.removePrizeFromUser(userPrizeId).subscribe({
      next: data => {
        this.prizeService.getPrizesByUserId(this.userId() as number).subscribe({
          next: prizes => {
            this.prizes = prizes;
          }
        })
      }
    })
  }
}
