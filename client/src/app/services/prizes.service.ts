import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';
import {AddPrizeToUserData, PrizeData, PrizeModel, UserPrizeInfoModel} from '../models/prize.models';

@Injectable({
  providedIn: 'root'
})
export class PrizesService {

  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  getPrizes(){
    return this.http.get<PrizeModel[]>(this.baseUrl+'/prize');
  }

  getPrizesByUserId(userId: number){
    return this.http.get<UserPrizeInfoModel[]>(this.baseUrl+'/prize/user/' + userId);
  }

  createPrize(data: PrizeData){
    return this.http.post<boolean>(this.baseUrl+'/prize', data);
  }

  addPrizeToUser(data: AddPrizeToUserData){
    return this.http.post<boolean>(this.baseUrl+'/userprize', data);
  }
  removePrizeFromUser(id: number){
    return this.http.delete<boolean>(this.baseUrl+'/userprize/'+id);
  }
}
