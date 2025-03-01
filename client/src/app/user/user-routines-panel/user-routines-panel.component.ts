import {Component, inject, input, OnInit} from '@angular/core';
import {DietService} from '../../services/diet.service';
import {UserDietDietCombined} from '../../models/diet.models';
import {MatDialog} from '@angular/material/dialog';
import {RoutineService} from '../../services/routine.service';
import {UserRoutineRoutineCombined} from '../../models/routine.models';
import {UserRoutineCardComponent} from '../user-routine-card/user-routine-card.component';

@Component({
  selector: 'app-user-routines-panel',
  imports: [
    UserRoutineCardComponent
  ],
  templateUrl: './user-routines-panel.component.html',
  styleUrl: './user-routines-panel.component.scss'
})
export class UserRoutinesPanelComponent  implements OnInit {
  userId = input.required<number>();
  editable = input.required<boolean>()
  routineService = inject(RoutineService)
  routines: UserRoutineRoutineCombined[] = []
  dialog = inject(MatDialog)
  ngOnInit() {
    this.routineService.getRoutinesByUserId(this.userId()).subscribe({
      next: data => {
        this.routines = data
      }
    })
  }
}
