import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserModel} from '../../models/user.models';
import {UserProfileComponent} from '../user-profile/user-profile.component';
import {UserDietsPanelComponent} from '../user-diets-panel/user-diets-panel.component';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {UserTrainingPlansPanelComponent} from '../user-training-plans-panel/user-training-plans-panel.component';
import {UserTrainingRecordsPanelComponent} from '../user-training-recods-panel/user-training-records-panel.component';
import {UserMeasuresPanelComponent} from '../user-measures-panel/user-measures-panel.component';

@Component({
  selector: 'app-user-home',
  imports: [
    UserProfileComponent,
    UserDietsPanelComponent,
    MatTabGroup,
    MatTab,
    UserTrainingPlansPanelComponent,
    UserTrainingRecordsPanelComponent,
    UserMeasuresPanelComponent
  ],
  templateUrl: './user-home.component.html',
  styleUrl: './user-home.component.scss'
})
export class UserHomeComponent implements OnInit {

  user: UserModel | undefined = undefined
  userService = inject(UserService)
  ngOnInit() {
    this.user = this.userService.userData()
  }
}
