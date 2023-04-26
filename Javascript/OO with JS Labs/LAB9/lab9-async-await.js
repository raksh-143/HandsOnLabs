//9. [Async/await] Use Async Programming for displaying a Thank You message if customer gives rating more than 3.

//Step1: Get the form whose id is 'ratingForm'. 
var form = document.getElementById('ratingForm')
var button = document.getElementById('rateSubmit')
button.addEventListener('click',rateFunction);

//Step2: Create a async function rateFunction.
async function rateFunction(){
    //Step2.a: Get the rating value from select id 'ratingId'.
    var rating = parseInt(document.getElementById('ratingId').value)
    //Step2.b: Create a promise to get the succes message "Thank You!" if rating is greater then 3.
    var myPromise = new Promise(function(resolve,reject){
        if(rating > 3){
            resolve('Thank You!')
        }
        else{
            reject('Sorry!')
        }
    })
    //Step2.c: Use 'await' to make sure async function is executed and diaplay the message of promise in 'p' id of 'rateMessage'.
    try{
        var result = await myPromise
        document.getElementById('rateMessage').innerHTML = result
    }
    catch(error){
        document.getElementById('rateMessage').innerHTML = error
    }
}






