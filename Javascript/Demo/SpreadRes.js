// let arr = [1,2,3,'abd']
// let arr1 = [4,5,6]

// //arr = arr.concat(arr1)
// arr = [...arr, ...arr1]

// console.log(arr)

// function add(a,b){
//     return a+b;
// }
// function addarray(...input){
//     let sum=0;
//     for(let num of input){
//         sum += parseInt(num)
//     }
//     return sum
// }

// console.log(add(1,2,3,4,5))
// console.log(addarray(1,2,3,4,5))


// let arr = ["My ","name "]
// let arr1 = ["is ","Rakshitha"]

// arr = [...arr, ...arr1]

// console.log(arr)

// function add(a,b){
//     return a+b;
// }
// function addarray(...input){
//     let sum="";
//     for(let num of input){
//         sum += num
//     }
//     return sum
// }

// console.log(add("My ","name "))
// console.log(addarray("My ","name ","is ","Rakshitha"))

// function neww(){
//     const promise = new Promise(function(resolve,reject){
//         const x = 'hello'
//         const y = 'Hello'
//         if(x==y){
//             resolve('strings are same')
//         }
//         else{
//             reject('strings are not same')
//         }
//     })
//     promise.then(function(){
//         console.log('resolved state')
//     })
//     .catch(function(){
//         console.log('rejected state')
//     })
//     return promise
// }

// async function demopromise(){
//     // try{
//     //     let msg = await neww()
//     //     console.log("Output: "+msg)
//     // }
//     // catch(err){
//     //     console.log("Error: "+err)
//     // }
// }
// demopromise()

//neww()

function neww(){
    var uname = document.forms['myform']['uname'].value
    var pword = document.forms['myform']['pword'].value

    const promise = new Promise(function(resolve,reject){
        const username = 'hello@123'
        const password = 'HelloWorld'
        if(username==uname && password==pword){
            resolve('User login successful')
        }
        else{
            reject('User login failed')
        }
    })
    promise.then(function(){
        alert('User login successful')
    })
    .catch(function(){
        alert('User login failed')
    })
    return promise
}