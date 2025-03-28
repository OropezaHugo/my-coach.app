import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {UserAchievementModel} from '../models/achievement.models';
import {AvatarModel} from '../models/avatar.models';

@Injectable({
  providedIn: 'root'
})
export class AvatarService {

  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getAllAvatars(){
    return this.http.get<AvatarModel[]>(`${this.baseUrl}/avatar`);
  }
}
