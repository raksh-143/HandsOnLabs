//Write your typescript code here
var itemPrice = 50;
var deliveryCharge = 15.6;
function totalPrice(itemPrice, deliveryCharge, showRes) {
    if (showRes == true) {
        console.log("Function: Total Price of the order is: " + (itemPrice + deliveryCharge));
    }
    else {
        return "Outside: Total Price of the order is: " + (itemPrice + deliveryCharge);
    }
}
//print the message in console
totalPrice(itemPrice, deliveryCharge, true);
console.log(totalPrice(itemPrice, deliveryCharge, false));
