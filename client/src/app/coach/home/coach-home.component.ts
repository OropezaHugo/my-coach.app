import { Component } from '@angular/core';
import {StudentsPanelComponent} from '../students/students-panel/students-panel.component';
import {UserHomeComponent} from '../../user/user-home/user-home.component';
import {MatExpansionPanel, MatExpansionPanelHeader} from '@angular/material/expansion';

@Component({
  selector: 'app-home',
  imports: [
    StudentsPanelComponent,
    UserHomeComponent,
    MatExpansionPanel,
    MatExpansionPanelHeader,
  ],
  templateUrl: './coach-home.component.html',
  styleUrl: './coach-home.component.scss'
})
export class CoachHomeComponent {

}
