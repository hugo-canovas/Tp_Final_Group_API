import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Employee } from '../models/employee.interface';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getAllEmployess(): Observable<Employee[]> {
    return this.http.get<Employee[]>(environment.URL_EMPLOYESS);
  }

  createEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(environment.URL_CREATE_EMPLOYEE, employee);
  }

  updateEmployee(employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(
      environment.URL_UPDATE_EMPLOYEE + `/${employee.id}`,
      employee
    );
  }

  deleteEmployee(id: number): Observable<Employee> {
    return this.http.delete<Employee>(
      environment.URL_DELETE_EMPLOYEE + `/${id}`
    );
  }
}
