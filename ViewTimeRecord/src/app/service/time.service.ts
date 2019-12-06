import { Injectable } from '@angular/core';
import { Time } from '../model/time';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TimeService {
  selectTime: Time;
  times = [];
  readonly URL_API = 'http://localhost:59882/api/Time';
  constructor(private http: HttpClient) { 
    this.selectTime = new Time();
  }
  getTimes(){
    return this.http.get(this.URL_API)
  }

  createTime(time: Time) {
      return this.http.post(this.URL_API, time);
  }

  updateTime(time: Time) {
      return this.http.put(this.URL_API + `/${time.id}`, time);
  }

  deleteTime(id: number) {
      return this.http.delete(this.URL_API + `/${id}`);
  }
}
