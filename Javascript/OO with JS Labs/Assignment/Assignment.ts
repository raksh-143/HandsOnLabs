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

//Assignment

//Get all the customers in 'amazon' company
var customers = company.getCustomer()
for(let customer of customers){
    console.log(customer.getName())
}
//Get all the items available in 'amazon' company
var items = company.getitem()
for(let item of items){
    console.log(item.getdescription())
}
//Get the total quantity ordered for each item from the company with the total price
var totalQty = 0
for(let customer of customers){
    var orders = customer.getorder()
    for(let order of orders){
        var ordereditems = order.getorderitem()
        for(let ordereditem of ordereditems){
            var qty = ordereditem.getquantity()
            totalQty += qty
        }
    }
}
console.log(totalQty)
//Get the nteworth of the company
var networth = company.gettotaolworthoforders()
console.log(networth)