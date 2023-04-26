//Write your typescript code here
var itemPrice = 50;
var deliveryCharge = 15.6;
function totalPrice(itemPrice, deliveryCharge, showRes, customString) {
    var output = "The " + customString + " Price is " + (itemPrice + deliveryCharge) + " including the delivery charge of " + deliveryCharge;
    if (showRes == true) {
        console.log(output);
    }
    else {
        return output;
    }
}
//print the message in console
totalPrice(itemPrice, deliveryCharge, true, "Chocolate Shake");
console.log(totalPrice(itemPrice, deliveryCharge, false, "Sandwich"));
