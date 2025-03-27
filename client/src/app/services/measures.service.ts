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
    return this.http.get<ISAKMeasuresModel[]>(`${this.baseUrl}/isakmeasures/user/${userId}`)
  }

  createISAKMeasure(data: ISAKMeasuresData){
    return this.http.post<boolean>(`${this.baseUrl}/isakmeasures`,data)
  }

  updateISAKMeasure(id: number, data: ISAKMeasuresData){
    return this.http.put<boolean>(`${this.baseUrl}/isakmeasures/${id}`,data)
  }
  getLastMeasureIn3MonthsByUserId(userId: number){
    return this.http.get<ISAKMeasuresModel>(`${this.baseUrl}/isakmeasures/user/${userId}/last`)
  }
}
