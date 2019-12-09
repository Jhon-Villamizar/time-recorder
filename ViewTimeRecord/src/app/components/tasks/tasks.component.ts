import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/service/task.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss']
})
export class TasksComponent implements OnInit {

  constructor(private taskService: TaskService) { }
  tasks = true;
  times = false;//inicia en false
  ngOnInit() {
    this.loadTasks()
  }

  loadTasks() {
    this.taskService.getTasks()
      .subscribe(res => {
        this.taskService.tasks = res as [];
        this.choiseForId();
      })
  }
  tasksForId = [];
  choiseForId() {
    var x = this.taskService.tasks;
    var id = parseInt(localStorage.getItem('employeeId'));
    x.forEach(element => {
      if (element.employeeId == id) {
        this.tasksForId.push(element);
      }
    });
  }

  nameTask = false;
  descripTask = false;
  sendTask(form?: NgForm) {
    if (form.value.name == "" || form.value.name == null) {
      this.nameTask = true;
      this.descripTask = false;
    } else if (form.value.description == "" || form.value.description == null) {
      this.nameTask = false;
      this.descripTask = true;
    } else {
      form.value.employeeId = localStorage.getItem('employeeId');
      this.taskService.createTask(form.value)
        .subscribe(res => {
          this.loadTasks();
          this.borrarForm(form);
        });
        this.nameTask = false;
        this.descripTask = false;
    }
  }

  borrarForm(form?: NgForm) {
    if (form) {
      form.reset();
    }
  }

  timeRegistry(id) {
    this.times = true;
    this.tasks = false;
    localStorage.setItem('taskId', id);
  }

  return() {
    this.times = false;
    this.tasks = true;
  }

}
