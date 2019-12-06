import { Injectable } from '@angular/core';
import { Task } from '../model/task';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  selectTask: Task;
  tasks = [];
  readonly URL_API = 'http://localhost:59882/api/Task';
  constructor(private http: HttpClient) { 
    this.selectTask = new Task();
  }
  getTasks(){
    return this.http.get(this.URL_API)
  }

  createTask(task: Task) {
      return this.http.post(this.URL_API, task);
  }

  updateTask(task: Task) {
      return this.http.put(this.URL_API + `/${task.id}`, task);
  }

  deleteTask(id: number) {
      return this.http.delete(this.URL_API + `/${id}`);
  }
}
