//Write your typescript code here
var itemPrice = 50;
var deliveryCharge = 15.6;
function totalPrice(itemPrice, deliveryCharge, showRes, customString) {
    if (showRes == true) {
        console.log(customString + (itemPrice + deliveryCharge));
    }
    else {
        return customString + (itemPrice + deliveryCharge);
    }
}
//print the message in console
totalPrice(itemPrice, deliveryCharge, true, "Chocolate Shake Price: ");
console.log(totalPrice(itemPrice, deliveryCharge, false, "Sandwich Price: "));
