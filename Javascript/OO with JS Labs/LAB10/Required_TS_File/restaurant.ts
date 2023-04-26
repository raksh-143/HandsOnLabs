import {item} from "./item";
import {Customer} from "./customer";
import {IdGenerator} from "./idgenerator";
 export class restaurant  {
customerId :number
name: string
item: item[]=[];
customer: Customer[]=[];

constructor(_name: string){
    this.name = _name ;
}
getName() {
    return this.name;
}
 getcustomerId(): number {
    return IdGenerator.customerid++;
}
getitem():item[]{
return this.item;
}
getCustomer():Customer[]{
return this.customer;
}

gettotaolworthoforders():number{
    let networth=0
        for(let customer of this.getCustomer()){
            for(let order of customer.getorder()){
                for(let item of order.getorderitem()){
                    networth+=item.totalprice;
                }
            }
        }
        return networth;
}


}


