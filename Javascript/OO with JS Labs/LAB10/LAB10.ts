import {restaurant} from  "./Required_TS_File/restaurant";
import {Customer} from  "./Required_TS_File/customer";
import {RegCustomer} from "./Required_TS_File/regcustomer";
import {order} from "./Required_TS_File/order";
import {item} from "./Required_TS_File/item";
import {orderitem} from "./Required_TS_File/orderitem";

//Create an object for company with name 'amazom'
var company = new restaurant("Amazon")
//Create 4 items: 'Bag' with price of 500, 'Books' with price of 1000, 'pen' with price of 200 and box with price of 100.
var item1 = new item(500,'Bag')
var item2 = new item(1000,'Books')
var item3 = new item(200,'Pen')
var item4 = new item(100,'Box')
//Add The 4 items to the company 'Amazon'
company["Items"] = [item1,item2,item3,item4]
//Create two orderitem object. One with 3 quantity of bag and other with 4 quantity of books
let oi1 = new orderitem(3,[item1])
let oi2 = new orderitem(4,[item2])
//Create an object of order and add the above two orderitem in it
let order1 = new order()
order1.orderitem = [oi1,oi2]
//Create another two orderitem object. One with 4 quantity of pen and other with 5 quantity of box.
let oi3 = new orderitem(4,[item3])
let oi4 = new orderitem(5,[item4])
//Create another object of order and add the above two orderitem in it
let order2 = new order()
order2.orderitem = [oi3,oi4]
//Create a new customer with name 'Shaurya'
let customer1 = new Customer("Shaurya")
//Create a new reg customer with name 'Agnihotri' which will get a discount of 10%
let regcustomer1 = new RegCustomer("Agnihotri",10)
//Add order1 for customer 'Shaurya'
customer1.order = [order1]
//Add order2 for the reg customer 'Agnihotri'
regcustomer1.order = [order2]
//Push both the customer in 'amazon' company
company.customer = [customer1,regcustomer1]
//Print all the details of the customer and orders as shown below:
// restaurant name is: amazon
console.log(`restaurant name is: ${company.name}`)
// customer is: charan
console.log(`customer is: ${customer1.getName()}`)
// customerid is: 1
console.log(`customerid is: ${customer1.getcustomerId()}`)
// orderid is: 1
console.log(`orderid is: ${customer1.getorder()[0].getOrderid()}`)
// ordered quantity of item1: 3 
// ordered quantity of item2: 4
var ordereditems = customer1.getorder()[0].getorderitem()
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getquantity()}`)
}
// description(item1) is:  bag  
// description(item2) is:  books
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getitem()[0].getdescription()}`)
}
// price of item1 is500
// price of item2 is1000
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getitem()[0].getprice()}`)
}
// iteamid for item1: 1
// iteamid for item2: 2
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getitem()[0].getitemId()}`)
}
// reg customer is: satya
console.log(`reg customer is: ${regcustomer1.getName()}`)
// regcostomerid is: 2
console.log(`reg customerid is: ${regcustomer1.getcustomerId()}`)
// regcustomer orderid :2
console.log(`regcustomer orderid is: ${regcustomer1.getorder()[0].getOrderid()}`)
// ordered quantity: 4
// ordered quantity: 5
var ordereditems = regcustomer1.getorder()[0].getorderitem()
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getquantity()}`)
}
// description(item1 in order2) is:  pen
// description(item2 in order2) is:  box
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getitem()[0].getdescription()}`)
}
// price of item3 is200
// price of item4 is100
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getitem()[0].getprice()}`)
}
// iteamid for item3: 3
// iteamid for item4: 4
for(let i=0;i<ordereditems.length;i++){
    console.log(`ordered quantity of item${i+1}: ${ordereditems[i].getitem()[0].getitemId()}`)
}