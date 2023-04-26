export class IdGenerator {
    public static customerid:number = 1;
     public static orderid :number = 1;
      public static itemid :number = 1;

    public static getcustomerId(): number {
        return IdGenerator.customerid++;
    }
    public static getorderId(): number {
        return IdGenerator.orderid++;
    }
    public static getitemId(): number {
        return IdGenerator.itemid++;
    }

}
