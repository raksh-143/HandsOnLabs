//Write your typescript code here
var itemPrice:number = 50
var deliveryCharge:number = 15.6

function totalPrice(itemPrice:number, deliveryCharge:number, showRes:boolean,customString:string){
    if(showRes==true){
        console.log(customString+(itemPrice+deliveryCharge))
    }
    else{
        return customString+(itemPrice+deliveryCharge)
    }
}
//print the message in console
totalPrice(itemPrice,deliveryCharge,true,"Chocolate Shake Price: ")
console.log(totalPrice(itemPrice,deliveryCharge,false,"Sandwich Price: "))