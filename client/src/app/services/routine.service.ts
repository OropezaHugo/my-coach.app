import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {UserRoutineRoutineCombined} from '../models/routine.models';

@Injectable({
  providedIn: 'root'
})
export class RoutineService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  //routine
  getRoutinesByUserId(id: number){
    return this.http.get<UserRoutineRoutineCombined[]>(`${this.baseUrl}/routine/user/${id}`)
  }
}
