import {inject, Injectable, signal} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient, HttpUrlEncodingCodec} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {UserModel} from '../models/user.models';
import {GoogleUserInfo} from '../models/auth.models';
import {CookieService} from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseUrl;
  private http = inject(HttpClient)
  httpUrlCodec = new HttpUrlEncodingCodec
  cookieService = inject(CookieService)
  userData = signal<UserModel | undefined>(undefined)
  tokenData = signal<GoogleUserInfo | undefined>(undefined)
  getActualUserInfo(email: string) {
    return this.http.get<UserModel>(`${this.baseUrl}/User/email/${email}`).pipe(
      map(res => {
        this.userData.set(res)
      }),
    )
  }

  getUserById(id: number) {
    return this.http.get<UserModel>(`${this.baseUrl}/User/${id}`)
  }
  getTokenData() {
    let value = this.cookieService.get('auth_token')
    if (value.length > 2) {
      let base64Payload = JSON.parse(this.httpUrlCodec.decodeValue(value)).id_token.toString().split('.')[1]
      let jwtString = atob(base64Payload)
      let jwt: GoogleUserInfo = JSON.parse(jwtString)
      this.tokenData.set(jwt)
      return this.tokenData()
    }
    return undefined
  }

  getStudents() {
    return this.http.get<UserModel[]>(`${this.baseUrl}/user/role/2`)
  }

  logout(){
    this.cookieService.delete('auth_token', '/', undefined, false, 'Lax')
    window.location.reload()
  }
}
