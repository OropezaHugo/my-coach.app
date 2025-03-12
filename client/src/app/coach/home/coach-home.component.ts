import { Component } from '@angular/core';
import {StudentsPanelComponent} from '../students/students-panel/students-panel.component';
import {UserHomeComponent} from '../../user/user-home/user-home.component';
import {MatExpansionPanel, MatExpansionPanelHeader} from '@angular/material/expansion';
import {PrizeComponent} from '../../shared/prize/prize.component';

@Component({
  selector: 'app-home',
  imports: [
    StudentsPanelComponent,
    UserHomeComponent,
    MatExpansionPanel,
    MatExpansionPanelHeader,
    PrizeComponent,
  ],
  templateUrl: './coach-home.component.html',
  styleUrl: './coach-home.component.scss'
})
export class CoachHomeComponent {

}
