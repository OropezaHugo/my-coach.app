import {Component, inject, OnInit} from '@angular/core';
import {UserService} from '../../services/user.service';
import {UserModel} from '../../models/user.models';
import {UserProfileComponent} from '../user-profile/user-profile.component';

@Component({
  selector: 'app-user-home',
  imports: [
    UserProfileComponent
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
