import { Injectable } from '@angular/core';
import {HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiWarper } from 'src/api.warper';
import { DepartmentPosition } from 'src/app/models/apis/DepartmentPostion.api';

@Injectable({
  providedIn: 'root'
})
export class DepartmentPositionService {

  constructor(private httpClient:HttpClient) { }

  public searchExists(request:any):Observable<ApiWarper<DepartmentPosition>>{
    return this.httpClient.get<ApiWarper<DepartmentPosition>>("http://localhost:5287/departmentposition/search",{params: new HttpParams().appendAll(request)});
  }
  public searchAll(request:any):Observable<ApiWarper<DepartmentPosition[]>>{
    return this.httpClient.get<ApiWarper<DepartmentPosition[]>>("http://localhost:5287/departmentposition");
  }
}
