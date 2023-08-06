import { Injectable } from '@angular/core';
import {HttpClient, HttpParams } from '@angular/common/http';
import { EmployeeViewModel } from 'src/app/models/apis/employee.api';
import { Observable } from 'rxjs';
import { ApiMessage, ApiWarper } from 'src/api.warper';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient:HttpClient) { }

  public getAllEmployee(request:any):Observable<ApiWarper<EmployeeViewModel[]>>{
    return this.httpClient.get<ApiWarper<EmployeeViewModel[]>>("http://localhost:5287/Employee");
  }
  public save(request:any):Observable<ApiMessage>{
    return this.httpClient.post<ApiMessage>("http://localhost:5287/Employee",request);
  }
  public delete(request:any):Observable<ApiMessage>{
    return this.httpClient.delete<ApiMessage>("http://localhost:5287/Employee",{params:new HttpParams().appendAll(request)});
  }
}
