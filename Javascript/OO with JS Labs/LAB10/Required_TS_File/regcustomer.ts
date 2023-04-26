import {Customer} from "./customer";
export class RegCustomer extends Customer {
    discount: number;

   constructor( name: string, discount: number) {
       super(name);
       this.discount = discount;
   }
   getDiscount():number {
       return this.discount;
   }
   setDiscount(discount:number): void {
       this.discount = discount;
   }
}