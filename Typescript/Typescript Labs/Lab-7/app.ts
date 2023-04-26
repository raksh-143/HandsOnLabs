//Write your typescript code here
var itemPrice:number = 50
var deliveryCharge:number = 15.6

function totalPrice(itemPrice:number, deliveryCharge:number, showRes:boolean,customString:string){
    var output = "The "+customString+" Price is "+(itemPrice+deliveryCharge)+" including the delivery charge of "+deliveryCharge
    if(showRes==true){
        console.log(output)
    }
    else{
        return output
    }
}
//print the message in console
totalPrice(itemPrice,deliveryCharge,true,"Chocolate Shake")
console.log(totalPrice(itemPrice,deliveryCharge,false,"Sandwich"))