import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AwsServicesService {

  appLocalHost = 'https://localhost:7188/api/'
  userAppUrl = 'AWS/saveImage';

  constructor(private http: HttpClient) { }

  public savePhoto(request: any): Observable<any> {
    const url = `${this.appLocalHost}${this.userAppUrl}`;
    return this.http.post<any>(url, request);
  }
}
