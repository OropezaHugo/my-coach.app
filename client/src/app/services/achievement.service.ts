import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {UserAchievementModel, UserBadgeStateData} from '../models/achievement.models';

@Injectable({
  providedIn: 'root'
})
export class AchievementService {

  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getUserAchievementsDataByUserId(userId:number){
    return this.http.get<UserAchievementModel[]>(`${this.baseUrl}/achievement/user/${userId}`);
  }
  getUserBadgesByUserId(userId:number){
    return this.http.get<UserAchievementModel[]>(`${this.baseUrl}/achievement/user/${userId}/badges`);
  }
  updateUserBadge(id: number, data: UserBadgeStateData){
    return this.http.put<boolean>(`${this.baseUrl}/userachievement/${id}/badge`, data);
  }
}
