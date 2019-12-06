export class Employee {
    constructor(id = null, name = '', password = ''){
        this.id = id,
        this.name = name,
        this.password = password
    }
    id: number;
    name: string;
    password: string;
}
