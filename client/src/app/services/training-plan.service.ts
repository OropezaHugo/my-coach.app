import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {UserTrainingPlanTrainingPlanCombined} from '../models/routine.models';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlanService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  //training-plan
  getTrainingPlansByUserId(id: number){
    return this.http.get<UserTrainingPlanTrainingPlanCombined[]>(`${this.baseUrl}/trainingplan/user/${id}`)
  }
}
