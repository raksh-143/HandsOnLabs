import {IdGenerator} from "./idgenerator";
 export class item{
    itemId : number
    price : number
    descripion : string
    constructor(_price:number , _description: string ){
        this.price = _price;
        this.descripion= _description;
    }
     getitemId(): number {
        return IdGenerator.itemid++;
    }

    getprice() : number{
      return this.price;
    }
    getdescription() : string {
        return this.descripion;
    }

}