import { Injectable } from '@angular/core';
import { HttpClient, HttpStatusCode } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserServicesService {

  appLocalHost = 'https://localhost:7188/api/'
  userAppUrl = 'User/createUser';

  constructor(private http: HttpClient) { }


  public registerUser(request: User): Observable<any> {
    const url = `${this.appLocalHost}${this.userAppUrl}`;
    return this.http.post<any>(url, request);
  }

  public getPetTypes(): Observable<any> {
    const url = `${this.appLocalHost}$'User/petTypes'`;
    return this.http.get<any>(url);
  }  


}
