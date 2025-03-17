import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {
  ExerciseBasicData,
  TrainingRecordContent,
  TrainingRecordData,
  TrainingRecordModel
} from '../models/training-records.models';

@Injectable({
  providedIn: 'root'
})
export class TrainingRecordService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getTrainingRecordExercisesBasicDataByUserId(userId: number){
    return this.http.get<ExerciseBasicData[]>(this.baseUrl+'/trainingRecord/user/'+userId+ '/exercises');
  }
  getTrainingRecordsByUserIdAndExerciseId(userId: number, exerciseId: number){
    return this.http.get<TrainingRecordContent[]>(this.baseUrl+'/trainingRecord/user/'+userId+'/exercise/'+exerciseId);
  }

  getExercisesBasicData(){
    return this.http.get<ExerciseBasicData[]>(this.baseUrl+'/exercise/basicData');
  }
  createTrainingRecord(data: TrainingRecordData){
    return this.http.post<boolean>(this.baseUrl+'/trainingRecord', data);
  }
deleteRecordById(id: number){
    return this.http.delete<boolean>(this.baseUrl+'/trainingRecord/'+id);
}
}
