//Create a namespace PriceCalculator
var PriceCalculator;
(function (PriceCalculator) {
    //add a function OrderPrice(orderAmount, discount) to return the discounted order price
    function OrderPrice(orderAmount, discount) {
        return orderAmount - discount;
    }
    PriceCalculator.OrderPrice = OrderPrice;
})(PriceCalculator || (PriceCalculator = {}));
