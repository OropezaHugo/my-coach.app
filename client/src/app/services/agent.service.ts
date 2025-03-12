import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AgentService {

  baseUrl = "https://localhost:443/webhook/askdiet"
  http = inject(HttpClient)
  getDiet(message: string) {
    let params = new HttpParams()
    params = params.append('chatInput', message)
    return this.http.get<{output: string}>(`${this.baseUrl}`, {params})
  }
}
