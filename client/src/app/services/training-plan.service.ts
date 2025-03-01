import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {TrainingPlanContent, UserTrainingPlanTrainingPlanCombined} from '../models/training-plan.models';

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
  getTrainingPlanContentById(id: number){
    return this.http.get<TrainingPlanContent>(`${this.baseUrl}/trainingplan/${id}/content`)
  }
  //trainingPlan-Routine relation
  createRoutine(){

  }

}
