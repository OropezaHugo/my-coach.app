import {Component, inject, signal} from '@angular/core';
import {UserService} from '../../services/user.service';

@Component({
  selector: 'app-guest-home',
  imports: [],
  templateUrl: './guest-home.component.html',
  styleUrl: './guest-home.component.scss'
})
export class GuestHomeComponent {
  userService = inject(UserService)
}
