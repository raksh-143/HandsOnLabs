// let customer = {
//     firstName: "Anne",
//     age: 21,
//     address:{
//         state:"Karnataka",
//         city: "Bangalore",
//         pincode: "560037"
//     },
//     getComments(){
//         return "I am very happy with the service of this company."
//     },
//     getFavProducts(){
//         return "Electronics, Make Up and Dresses"
//     }
// }

// let employee = {
//     firstName: "Jack",
//     age: 25,
//     salary: 982733,
//     address:{
//         state:"Maharashtra",
//         city: "Mumbai"
//     },
//     getDetails(){
//         return `Employee Name: ${employee.firstName}; Employee Age: ${employee.age}`
//     },
//     getSalary(){
//         return `${employee.salary}`
//     }
// }

// console.log("Customer Information")
// console.log("Name: "+customer["firstName"])
// console.log("Comments: "+customer.getComments())
// console.log("Favorite Products: "+customer.getFavProducts())
// console.log()
// console.log("Employee Information")
// console.log("Name: "+employee["firstName"])
// console.log("Details: "+employee.getDetails())
// console.log("Salary: "+employee.getSalary())

// function student(firstName,age){
//     this.firstName = firstName
//     this.age = age
// }
// let student1 = new student('ada',23)
// console.log(student1.firstName)

// class student{
//     constructor(firstname,age){
//         this.firstname = firstname
//         this.age = age
//     }
//     addaddress(address){
//         this.address = address
//     }
//     getDetails(){
//         return `I am ${this.firstname}. I am ${this.age} years old. I live in ${this.address}`
//     }
// }
// let student1 = new student('ada',23)
// student1.addaddress('bangalore')
// console.log(student1.getDetails())

// class customer{
//     constructor(firstname,age,address){
//         this.firstname = firstname
//         this.age = age
//         this.address = address
//     }
//     addcomment(comment){
//         this.comment = comment
//     }
//     getDetails(){
//         return `I am ${this.firstname}. I am ${this.age} years old. I live in ${this.address}. ${this.comment}. My favorite products are ${this.getFavProducts()}.`
//     }
//     getFavProducts(){
//         return "Electronics, Make Up and Dresses"
//     }
// }
// let customer1 = new customer('ada',23,'Bangalore')
// customer1.addcomment('I was extremely happy with the service')
// console.log(customer1.getDetails())

class Person{
    constructor(firstname,age){
        this.firstname = firstname
        this.age = age
    }
    getDetails(){
        return `I am ${this.firstname}. I am ${this.age} years old.`
    }
}
class Customer extends Person{
    constructor(firstname,age,address){
        super(firstname,age)
        this.address = address
    }
    getDetails(){
        return `${super.getDetails()} I live in ${this.address}. ${this.comment}. My favorite products are ${this.getFavProducts()}.`
    }
    addcomment(comment){
        this.comment = comment
    }
    getFavProducts(){
        return this.favprod
    }
    addfavprod(prod){
        this.favprod = prod
    }
}
class Employee extends Person{
    constructor(email,firstname,age,address){
        super(firstname,age)
        this.email=email
        this.address = address
    }
    getDetails(){
        return `${super.getDetails()} I live in ${this.address}. ${this.comment}. My salary is ${this.getsalary()}`
    }
    addsalary(salary){
        this.salary = salary
    }
    getsalary(){
        return this.salary
    }
}

function submit1(){
    let email = document.forms["myform"]["email"].value
    let Name = document.forms["myform"]["name"].value
    let age = document.forms["myform"]["age"].value
    let address = document.forms["myform"]["address"].value
    let comment = document.forms["myform"]["comment"].value
    let favprod = document.forms["myform"]["favprod"].value
    let emailpat = /^\S+@\S+\.\S+$/
    if(email=='' || Name=='' || age=='' || address=='' || comment=='' || favprod==''){
        document.getElementById("output").innerHTML = 'Enter all the credentials'
    }
    else if(!emailpat.test(email)){
        document.getElementById("output").innerHTML = 'Enter email in proper format'
    }
    else{
        let cust1 = new Customer(email,Name,age,address)
        cust1.addcomment(comment)
        cust1.addfavprod(favprod)
        console.log(cust1.getDetails())
        document.getElementById("output").innerHTML = cust1.getDetails()
    }
}
function pageloadingdone(){
    document.getElementById("output").innerHTML = 'Page loaded'
}
