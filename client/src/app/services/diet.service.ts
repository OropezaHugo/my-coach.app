import {inject, Injectable} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DietService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)

  

}
