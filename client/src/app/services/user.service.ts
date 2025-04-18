import {inject, Injectable, signal} from '@angular/core';
import {environment} from '../../environments/environment.development';
import {HttpClient, HttpUrlEncodingCodec} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {UserData, UserModel} from '../models/user.models';
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
      let jwtString = atob(value.split('.')[1]);
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

  getCoaches() {
    return this.http.get<UserModel[]>(`${this.baseUrl}/user/role/1`)
  }

  updateUserData(id: number, user: UserData) {
    return this.http.put<boolean>(`${this.baseUrl}/user/${id}`, user)
  }
}
