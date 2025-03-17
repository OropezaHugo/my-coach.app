import {Component, inject, OnInit} from '@angular/core';
import {MatButton} from '@angular/material/button';
import {UserService} from '../../services/user.service';
import {GoogleUserInfo} from '../../models/auth.models';
import {NotificationsService} from '../../services/notifications.service';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-login',
  imports: [
    MatButton,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit{
  userService = inject(UserService)
  notificationService = inject(NotificationsService)
  tokenData: GoogleUserInfo | undefined = undefined;
  BaseUrl = environment.baseUrl;
  ngOnInit() {
    this.tokenData = this.userService.getTokenData()
  }

  loginWithGoogle() {
    window.location.href = `${this.BaseUrl}/Auth/login`; // Backend de .NET
  }

  logout() {
    this.userService.logout()
  }

  notifyMe() {
    let id = this.userService.userData()?.id
    if (id) {
      this.notificationService.subscribeToNotifications(id)
    }
  }
}
