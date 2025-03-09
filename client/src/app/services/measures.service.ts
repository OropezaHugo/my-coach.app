import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {ISAKMeasuresData, ISAKMeasuresModel} from '../models/measure.models';

@Injectable({
  providedIn: 'root'
})
export class MeasuresService {

  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getMeasuresByUserId(userId: number){
    return this.http.get<ISAKMeasuresModel[]>(`${environment.baseUrl}/isakmeasures/user/${userId}`)
  }

  createISAKMeasure(data: ISAKMeasuresData){
    return this.http.post<boolean>(`${environment.baseUrl}/isakmeasures`,data)
  }
  getLastMeasureIn3MonthsByUserId(userId: number){
    return this.http.get<ISAKMeasuresModel>(`${environment.baseUrl}/isakmeasures/user/${userId}/last`)
  }
}
