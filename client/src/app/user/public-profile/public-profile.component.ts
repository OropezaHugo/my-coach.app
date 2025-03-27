import {Component, input} from '@angular/core';
import {UserModel} from '../../models/user.models';
import {DatePipe} from '@angular/common';
import {UserBadgesPanelComponent} from '../user-badges-panel/user-badges-panel.component';
import {MatExpansionPanel, MatExpansionPanelHeader, MatExpansionPanelTitle} from '@angular/material/expansion';

@Component({
  selector: 'app-public-profile',
  imports: [
    DatePipe,
    UserBadgesPanelComponent,
    MatExpansionPanelHeader,
    MatExpansionPanel,
    MatExpansionPanelTitle
  ],
  templateUrl: './public-profile.component.html',
  styleUrl: './public-profile.component.scss'
})
export class PublicProfileComponent {
  user = input.required<UserModel>()
}
