export class Task {
    constructor(id = null, name = '', description = '', employeeId = null){
        this.id = id,
        this.name = name,
        this.description = description,
        this.employeeId = employeeId
    }
    id: number;
    name: string;
    description: string;
    employeeId: number;
}
