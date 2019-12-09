import { Component, OnInit } from '@angular/core';
import { TimeService } from 'src/app/service/time.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-times',
  templateUrl: './times.component.html',
  styleUrls: ['./times.component.scss']
})
export class TimesComponent implements OnInit {

  constructor(private timeService: TimeService) { }

  ngOnInit() {
    this.loadTimes();
  }

  loadTimes() {
    this.timeService.getTimes()
      .subscribe(res => {
        this.timeService.times = res as [];
        this.loadByTaskId();
      })
  }

  timesForId = [];
  allHours = 0;
  loadByTaskId() {
    var x = this.timeService.times;
    var id = parseInt(localStorage.getItem('taskId'));
    x.forEach(element => {
      if (element.taskId == id) {
        document.getElementById('times').innerHTML += `
          <tr>
            <td>${element.date}</td>
            <td>${element.hours}</td>
          </tr>
        `;
        this.allHours += element.hours;
      }
    });
    console.log(this.allHours);
  }
  dates = false;
  hour = false;
  sendTime(form?: NgForm) {
    if (form.value.date == "" || form.value.date == null) {
      this.dates = true;
      this.hour = false;
    } else if (form.value.hours == "" || form.value.hours == null) {
      this.hour = true;
      this.dates = false;
    } else {
      form.value.taskId = localStorage.getItem('taskId');
      if (this.allHours + form.value.hours > 8) {
        alert('se pasa de 8');
      } else {
        this.timeService.createTime(form.value)
          .subscribe(res => {
            document.getElementById('times').innerHTML = ``;
            this.loadTimes();
            this.borrarForm(form);
          })
      }
    }

  }

  borrarForm(form?: NgForm) {
    if (form) {
      form.reset();
    }
  }
}
