//Create a namespace PriceCalculator
namespace PriceCalculator{
    //add a function OrderPrice(orderAmount, discount) to return the discounted order price
    export function OrderPrice(orderAmount:number,discount:number):number{
        return orderAmount-discount
    }
}
