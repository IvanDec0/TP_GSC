import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { JwtDto } from '../models/jwt-dto';
import { LoginUser } from '../models/login-user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authURL = `${environment.apiBack}/users`;

  constructor(private httpClient: HttpClient) { }

  public login(loginUser: LoginUser): any {
    return this.httpClient.post(this.authURL + '/login', loginUser, {responseType: 'text'});
  }

  public register(loginUser: LoginUser): any {
    return this.httpClient.post(this.authURL + '/register', loginUser);
  }
}
