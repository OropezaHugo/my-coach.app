import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {UserAchievementModel} from '../models/achievement.models';

@Injectable({
  providedIn: 'root'
})
export class AchievementService {

  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getUserAchievementsDataByUserId(userId:number){
    return this.http.get<UserAchievementModel[]>(`${this.baseUrl}/achievement/user/${userId}`);
  }
}
