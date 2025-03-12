import {Component, inject, OnInit} from '@angular/core';
import {PrizesService} from '../../services/prizes.service';
import {PrizeModel} from '../../models/prize.models';
import {UserPrizesCardComponent} from '../../user/user-prizes-card/user-prizes-card.component';
import {MatDialog} from '@angular/material/dialog';
import {AddPrizeDialogComponent} from '../dialogs/add-prize-dialog/add-prize-dialog.component';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-prize',
  imports: [
    UserPrizesCardComponent,
    MatButton
  ],
  templateUrl: './prize.component.html',
  styleUrl: './prize.component.scss'
})
export class PrizeComponent implements OnInit {
  prizeService = inject(PrizesService)
  prizes: PrizeModel[] = []
  dialog = inject(MatDialog)
  ngOnInit() {
    this.prizeService.getPrizes().subscribe({
      next: data => {
        this.prizes = data;
      }
    })
  }
  OpenCreateNewPrizeDialog(){
    this.dialog.open(AddPrizeDialogComponent).afterClosed().subscribe({
      next: data => {
        this.prizeService.getPrizes().subscribe({
          next: prizes => {
            this.prizes = prizes;
          }
        })
      }
    })
  }
}
