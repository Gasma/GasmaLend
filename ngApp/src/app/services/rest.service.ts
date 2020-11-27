import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse } from '../models/apiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class RestService {
  readonly BaseUrl = 'http://localhost:65298/';

  constructor(private http: HttpClient) { }

  sendPostRequest(url: string, body: any)
  {
    return this.http.post<ApiResponse>(this.BaseUrl + url, body);
  }

  sendPutRequest(url: string, body: any)
  {
    return this.http.put<ApiResponse>(this.BaseUrl + url, body);
  }

  sendGetRequest(url: string)
  {
    return this.http.get<ApiResponse>(this.BaseUrl + url);
  }
}
