import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {
  CreateExerciseData,
  CreateRoutineData,
  CreateTrainingPlanData,
  ExerciseModel,
  ExerciseSetData,
  RoutineExerciseData,
  RoutineModel,
  SetData,
  SetModel,
  TrainingPlanContent, TrainingPlanData,
  TrainingPlanRoutineData, UserTrainingPlanData,
  UserTrainingPlanTrainingPlanCombined
} from '../models/training-plan.models';

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
  createTrainingPlan(newPlan: CreateTrainingPlanData){
    return this.http.post<TrainingPlanData>(`${this.baseUrl}/trainingplan`, newPlan)
  }

  addTrainingPlanToUserTrainingPlans(data: UserTrainingPlanData){
    return this.http.post<boolean>(`${this.baseUrl}/usertrainingplan`, data)
  }
  //trainingPlan-Routine relation
  createRoutine(routine: CreateRoutineData){
    return this.http.post<RoutineModel>(`${this.baseUrl}/routine`, routine)
  }
  addRoutineToTrainingPlan(data: TrainingPlanRoutineData) {
    return this.http.post<boolean>(`${this.baseUrl}/trainingplanroutine`, data)
  }

  deleteTrainingPlanRoutineById(id: number){
    return this.http.delete<boolean>(`${this.baseUrl}/trainingplanroutine/${id}`)
  }

  updateTrainingPlanRoutineById(id: number, data: TrainingPlanRoutineData){
    return this.http.put<boolean>(`${this.baseUrl}/trainingplanroutine/${id}`, data)
  }

  deleteRoutineExerciseById(id: number){
    return this.http.delete<boolean>(`${this.baseUrl}/routineexercise/${id}`)
  }
  createExercise(exercise: CreateExerciseData){
    return this.http.post<ExerciseModel>(`${this.baseUrl}/exercise`, exercise)
  }
  addExerciseToRoutine(data: RoutineExerciseData){
    return this.http.post<boolean>(`${this.baseUrl}/routineexercise`, data)
  }

  getSetsByExerciseId(id: number){
    return this.http.get<SetModel[]>(`${this.baseUrl}/set/exercise/${id}`)
  }
  createSet(newSet: SetData) {
    return this.http.post<SetModel>(`${this.baseUrl}/set`, newSet)
  }
  addSetToExercise(data: ExerciseSetData){
    return this.http.post<boolean>(`${this.baseUrl}/exerciseset`, data)
  }
  editSet(id: number, newSet: SetData) {
    return this.http.put<boolean>(`${this.baseUrl}/set/${id}`, newSet)
  }
  deleteSet(id: number){
    return this.http.delete<boolean>(`${this.baseUrl}/set/${id}`)
  }
}
