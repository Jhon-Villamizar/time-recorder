import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/service/employee.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }
  name = '';
  password = '';
  task = false;//inicia en false
  login = true;
  fieldsEmpty=false;
  nonUser=false;


  sendLogin(form?: NgForm) {
    this.name = form.value.name;
    this.password = form.value.password;
    if (form.value.name=="" || form.value.password=="" || form.value.name==null || form.value.password==null) {
      this. nonUser=false;
      this.fieldsEmpty=true;
    } else {
      this.employeeService.login(this.name, this.password)
      .subscribe(res => {
        var employeeId = String(res);
        localStorage.setItem('employeeId',employeeId);
        if (employeeId != '0') {
          this.task = true;
          this.login = false;
          this.borrarForm(form);
        } else {
          this.fieldsEmpty=false;
          this. nonUser=true;
          this.borrarForm(form);
        }
      });
    }
 
  }

  borrarForm(form?: NgForm) {
    if(form) {
      form.reset();
    }
  } 

  logout(){
    this.task = false;
    this.login = true;
    
  }
}
