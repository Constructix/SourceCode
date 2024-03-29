class Student {
    fullName: string;
    constructor(public firstName, public middleInitial, public lastName) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}


interface Person 
{
    firstName: string;
    lastName: string;
}


function greeter(person: Person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}

var user = new Student( "Richard", "J", "Jones");
var isDone : boolean;

isDone = false;
document.body.innerHTML = greeter(user);