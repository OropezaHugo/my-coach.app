import {Component, inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {PrizeModel, RewardUserDialogData} from '../../../models/prize.models';
import {PrizesService} from '../../../services/prizes.service';
import {UserPrizesCardComponent} from '../../../user/user-prizes-card/user-prizes-card.component';

@Component({
  selector: 'app-reward-user-dialog',
  imports: [
    MatDialogContent,
    UserPrizesCardComponent
  ],
  templateUrl: './reward-user-dialog.component.html',
  styleUrl: './reward-user-dialog.component.scss'
})
export class RewardUserDialogComponent implements OnInit{
  dialogRef = inject(MatDialogRef<RewardUserDialogComponent>);
  data = inject<RewardUserDialogData>(MAT_DIALOG_DATA);
  prizeService = inject(PrizesService)
  prizes: PrizeModel[] = []

  ngOnInit() {
    this.prizeService.getPrizes().subscribe({
      next: data => {
        this.prizes = data;
      }
    })
  }


  rewardUserWithPrize(event: number) {
    this.prizeService.addPrizeToUser({
      userId: this.data.userId,
      prizeId: event,
      obtainedDate: new Date().toISOString().split('T')[0],
    }).subscribe({
      next: data => {
        this.dialogRef.close()
      }
    })
  }
}
