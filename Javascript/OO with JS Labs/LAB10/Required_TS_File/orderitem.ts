import {item} from "./item";
export class orderitem{
     totalprice: number
    item:item[]=[];
    quantity:number
    constructor(_quantity:number,item:item[]){
        for (const items of item) {
           
                this.item.push(items);
                this.quantity=_quantity;
                this.totalprice=_quantity*items.getprice();
                break;
            
        }
    }
    setquantity(_qty:number): void{
     this.quantity = _qty;
    }
    getquantity() : number{
        return this.quantity;
    }
    getitem():item[]{
     return this.item;
    }
   
   
}