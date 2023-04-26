import {orderitem} from "./orderitem";
import {IdGenerator} from "./idgenerator";
 export class order{

     orderitem:orderitem[]=[];
    private orderid : number 
    constructor(){
        this.orderid=IdGenerator.getorderId();
    }
    getOrderid() : number{
        return this.orderid;
    }
    getorderitem():orderitem[]{
        return this.orderitem
    }
    setOrderItem(_orderItem:orderitem){
        this.orderitem.push(_orderItem);
    }
    
}