const add = (a,b)=>{
    return a+b;
}

//console.log(add(4,6))


let altitude = 10;
let base = 20;

function square(){
    sqr = 0.5 * (base + altitude)
    console.log(sqr)
}

//square()

const greeting = ()=>{
    console.log("Hello User!")
    document.write("Hello User!")
}

//greeting()

const simpleInterest = (p,t,r) =>{
    console.log(p * t * r / 100);
}

// var p = prompt("Enter principle amount:")
// var r = prompt("Enter rate of interest:")
// var t = prompt("Enter time in years:")

// simpleInterest(p,r,t)

const prompt = require('prompt-sync')();

const oddoreven = (n) =>{
    if(n%2==0){
        console.log("Even")
    }
    else{
        console.log("Odd")
    }
}

//const a = prompt("Enter a number:")

//oddoreven(a)

const studentResult = (marks1,marks2,marks3)=>{
    marks1 = parseInt(marks1)
    marks2 = parseInt(marks2)
    marks3 = parseInt(marks3)
    var sum = marks1 + marks2 + marks3;
    var avg = sum / 3;
    var first = marks1;
    var second = marks1;
    if(marks2 > marks1 && marks2 > marks3){
        first = marks2;
        if(marks3 > marks1){
            second = marks3;
        }
    }
    else if(marks3 > marks1 && marks3 > marks2){
        first = marks3;
        if(marks2>marks1){
            second = marks2;
        }
    }
    var result = "";
    if(avg > 60){
        result = "First Class"
    }
    else if(avg > 35 && avg < 60){
        result = "Second Class"
    }
    else{
        result = "Fail"
    }
    console.log(sum);
    console.log(avg);
    console.log(first);
    console.log(second);
    console.log(result);
}

var marks1 = prompt()
var marks2 = prompt()
var marks3 = prompt()
studentResult(marks1,marks2,marks3)