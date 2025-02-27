import {Component, inject, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {UserService} from '../../services/user.service';
import {CookieService} from "ngx-cookie-service";
import {HttpUrlEncodingCodec} from "@angular/common/http";
import {GoogleUserInfo} from "../../models/auth.models";

@Component({
  selector: 'app-callback',
  imports: [],
  templateUrl: './callback.component.html',
  styleUrl: './callback.component.scss'
})
export class CallbackComponent implements OnInit {

  router = inject(Router)
  cookieService = inject(CookieService)
  httpUrlCodec = new HttpUrlEncodingCodec
  userService = inject(UserService)

  ngOnInit() {
    let jwt = this.userService.getTokenData()
    if (jwt) {
      this.userService.getUserInfo(jwt.email).subscribe({
        next: user => {
          if (this.userService.userData()?.roleId === 1) {
            this.router.navigateByUrl('/coach/home')
          }
          else if (this.userService.userData()?.roleId === 2) {
            this.router.navigateByUrl('/student/home')
          } else {
            this.router.navigateByUrl('/guest/home')
          }
        }
      })
    } else {
      this.router.navigateByUrl('/guest/home')
    }

  }
}
