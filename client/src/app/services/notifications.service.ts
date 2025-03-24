import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {SwPush} from '@angular/service-worker';
import {UserModel} from '../models/user.models';
import {convertBrowserOptions} from '@angular-devkit/build-angular/src/builders/browser-esbuild';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)
  private swPush = inject(SwPush)
  private VAPID_PUBLIC_KEY = 'BEWTYpe7L0TkDzggdrZSLzpb4tRW_H67Xw_euy1WoIo3FMGHx8cIQkqTHzxcI67zqrJYHGRGUf6tb1mboaqiHJI';

  subscribeToNotifications(userId: number) {
    if (this.swPush.isEnabled) {
      this.swPush.requestSubscription({
        serverPublicKey: this.VAPID_PUBLIC_KEY
      }).then(subscription => {
        this.http.put<boolean>(`${this.baseUrl}/user/${userId}/subscribe`, {
          endpoint: subscription.endpoint,
          auth: subscription.toJSON().keys!['auth'],
          p256dh: subscription.toJSON().keys!['p256dh']
        }).subscribe();
      }).catch(error => {
        console.log(error);
      })
    }
  }
}
