import {Component, inject, input, numberAttribute, OnInit} from '@angular/core';
import {UserService} from '../../../services/user.service';
import {UserModel} from '../../../models/user.models';
import {UserDietsPanelComponent} from '../../../user/user-diets-panel/user-diets-panel.component';
import {UserProfileComponent} from '../../../user/user-profile/user-profile.component';
import {MatButton} from '@angular/material/button';
import {RouterLink} from '@angular/router';
import {MatTab, MatTabGroup} from '@angular/material/tabs';
import {UserTrainingPlansPanelComponent} from '../../../user/user-training-plans-panel/user-training-plans-panel.component';
import {
  UserTrainingRecordsPanelComponent
} from '../../../user/user-training-recods-panel/user-training-records-panel.component';

@Component({
  selector: 'app-student-profile',
  imports: [
    UserDietsPanelComponent,
    UserProfileComponent,
    MatButton,
    RouterLink,
    MatTabGroup,
    MatTab,
    UserTrainingPlansPanelComponent,
    UserTrainingRecordsPanelComponent
  ],
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.scss'
})
export class StudentProfileComponent implements OnInit {
  userId = input.required<number>()
  user?: UserModel = undefined
  userService = inject(UserService)
  ngOnInit() {
    this.userService.getUserById(this.userId() as number).subscribe({
      next: data => {
        this.user = data
      }
    })
  }
}
