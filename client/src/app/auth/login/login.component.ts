import {Component, inject, OnInit} from '@angular/core';
import {MatButton} from '@angular/material/button';
import {UserService} from '../../services/user.service';
import {NgOptimizedImage} from '@angular/common';
import {GoogleUserInfo} from '../../models/auth.models';
import {NotificationsService} from '../../services/notifications.service';

@Component({
  selector: 'app-login',
  imports: [
    MatButton,
    NgOptimizedImage
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit{
  userService = inject(UserService)
  notificationService = inject(NotificationsService)
  tokenData: GoogleUserInfo | undefined = undefined;
  ngOnInit() {
    this.tokenData = this.userService.getTokenData()
  }

  loginWithGoogle() {
    window.location.href = 'http://localhost:5050/Auth/login'; // Backend de .NET
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
