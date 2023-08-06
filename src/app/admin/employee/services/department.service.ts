import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiMessage, ApiWarper } from 'src/api.warper';
import { Department } from 'src/app/models/apis/Department.api';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private httpClient:HttpClient) { }

  public getAllDepartment(request:any):Observable<ApiWarper<Department[]>>{
    return this.httpClient.get<ApiWarper<Department[]>>("http://localhost:5287/Department");
  }
  public save(request:any):Observable<ApiMessage>{
    return this.httpClient.post<ApiMessage>("http://localhost:5287/Department",request);
  }
}
