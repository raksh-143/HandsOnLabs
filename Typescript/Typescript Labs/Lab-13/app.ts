//Import the namespace
///<reference path='./PriceCalc.ts'/>
//get the total price from the PriceCalculator namespace
let totalOrderPrice = PriceCalculator.OrderPrice(500,150);
//execute to display the output
console.log('Total price of the order is: '+ totalOrderPrice);