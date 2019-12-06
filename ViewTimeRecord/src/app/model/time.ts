export class Time {
    constructor(id = null, date = null, hours = null, taskId = null){
        this.id = id,
        this.date = date,
        this.hours = hours,
        this.taskId = taskId
    }
    id: number;
    date: Date;
    hours: number;
    taskId: number;
}
