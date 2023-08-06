import { Injectable } from '@angular/core';
import {HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiMessage, ApiWarper } from 'src/api.warper';
import { Position } from 'src/app/models/apis/Position.api';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  constructor(private httpClient:HttpClient) { }

  public getAllPosition(request:any):Observable<ApiWarper<Position[]>>{
    console.log(request)
    return this.httpClient.get<ApiWarper<Position[]>>("http://localhost:5287/Position",{params: new HttpParams().appendAll(request)});
  }
  public save(request:any):Observable<ApiMessage>{
    return this.httpClient.post<ApiMessage>("http://localhost:5287/Position",request);
  }
}
