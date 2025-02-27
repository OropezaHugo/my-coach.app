import {Component, input} from '@angular/core';
import {UserModel} from '../../models/user.models';

@Component({
  selector: 'app-user-profile',
  imports: [],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss'
})
export class UserProfileComponent {
  user = input.required<UserModel>()
}
