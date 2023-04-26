import {IdGenerator} from "./idgenerator";
import {order}  from "./order";

 export class Customer {
     order:order[]=[];
    
    protected name: string;
    customerId:number;

    constructor(_name: string) {
        this.name = _name;
    }
    getName():string {
        return this.name;
    }
    setName(_name : string) : void {
        this.name = _name;
    }
     getcustomerId(): number {
        return IdGenerator.customerid++;
    }
    getorder():order[]{
        return this.order
    }
    setOrder(_order:order):void{
        this.order.push(_order)
    }
    
}
