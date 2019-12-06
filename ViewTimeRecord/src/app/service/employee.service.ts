import { Injectable } from '@angular/core';
import { Employee } from '../model/employee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  SelectEmployee: Employee;
  employees = [];
  readonly URL_API = 'http://localhost:59882/api/Employee';
  constructor(private http: HttpClient) { 
    this.SelectEmployee = new Employee();
  }
  getEmployees(){
    return this.http.get(this.URL_API)
  }

  login(name: string, password: string) {
    return this.http.get(this.URL_API + `/?name=${name}&password=${password}`);
  }

  createEmployee(employee: Employee) {
      return this.http.post(this.URL_API, employee);
  }

  updateEmployee(employee: Employee) {
      return this.http.put(this.URL_API + `/${employee.id}`, employee);
  }

  deleteEmployee(id: number) {
      return this.http.delete(this.URL_API + `/${id}`);
  }
}
