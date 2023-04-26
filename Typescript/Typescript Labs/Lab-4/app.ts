//Write your typescript code here
var itemPrice:number = 50
var deliveryCharge:number = 15.6

function totalPrice(itemPrice:number, deliveryCharge:number):number{
    return itemPrice+deliveryCharge
}
//print the message in console
console.log("Total Price of the order is: "+totalPrice(itemPrice,deliveryCharge))