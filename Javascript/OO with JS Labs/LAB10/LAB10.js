"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var restaurant_1 = require("./Required_TS_File/restaurant");
var customer_1 = require("./Required_TS_File/customer");
var regcustomer_1 = require("./Required_TS_File/regcustomer");
var order_1 = require("./Required_TS_File/order");
var item_1 = require("./Required_TS_File/item");
var orderitem_1 = require("./Required_TS_File/orderitem");
//Create an object for company with name 'amazom'
var company = new restaurant_1.restaurant("Amazon");
//Create 4 items: 'Bag' with price of 500, 'Books' with price of 1000, 'pen' with price of 200 and box with price of 100.
var item1 = new item_1.item(500, 'Bag');
var item2 = new item_1.item(1000, 'Books');
var item3 = new item_1.item(200, 'Pen');
var item4 = new item_1.item(100, 'Box');
//Add The 4 items to the company 'Amazon'
company["Items"] = [item1, item2, item3, item4];
//Create two orderitem object. One with 3 quantity of bag and other with 4 quantity of books
var oi1 = new orderitem_1.orderitem(3, [item1]);
var oi2 = new orderitem_1.orderitem(4, [item2]);
//Create an object of order and add the above two orderitem in it
var order1 = new order_1.order();
order1.orderitem = [oi1, oi2];
//Create another two orderitem object. One with 4 quantity of pen and other with 5 quantity of box.
var oi3 = new orderitem_1.orderitem(4, [item3]);
var oi4 = new orderitem_1.orderitem(5, [item4]);
//Create another object of order and add the above two orderitem in it
var order2 = new order_1.order();
order2.orderitem = [oi3, oi4];
//Create a new customer with name 'Shaurya'
var customer1 = new customer_1.Customer("Shaurya");
//Create a new reg customer with name 'Agnihotri' which will get a discount of 10%
var regcustomer1 = new regcustomer_1.RegCustomer("Agnihotri", 10);
//Add order1 for customer 'Shaurya'
customer1.order = [order1];
//Add order2 for the reg customer 'Agnihotri'
regcustomer1.order = [order2];
//Push both the customer in 'amazon' company
company.customer = [customer1, regcustomer1];
//Print all the details of the customer and orders as shown below:
// restaurant name is: amazon
console.log("restaurant name is: ".concat(company.name));
// customer is: charan
console.log("customer is: ".concat(customer1.getName()));
// customerid is: 1
console.log("customerid is: ".concat(customer1.getcustomerId()));
// orderid is: 1
console.log("orderid is: ".concat(customer1.getorder()[0].getOrderid()));
// ordered quantity of item1: 3 
// ordered quantity of item2: 4
var ordereditems = customer1.getorder()[0].getorderitem();
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getquantity()));
}
// description(item1) is:  bag  
// description(item2) is:  books
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getitem()[0].getdescription()));
}
// price of item1 is500
// price of item2 is1000
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getitem()[0].getprice()));
}
// iteamid for item1: 1
// iteamid for item2: 2
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getitem()[0].getitemId()));
}
// reg customer is: satya
console.log("reg customer is: ".concat(regcustomer1.getName()));
// regcostomerid is: 2
console.log("reg customerid is: ".concat(regcustomer1.getcustomerId()));
// regcustomer orderid :2
console.log("regcustomer orderid is: ".concat(regcustomer1.getorder()[0].getOrderid()));
// ordered quantity: 4
// ordered quantity: 5
var ordereditems = regcustomer1.getorder()[0].getorderitem();
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getquantity()));
}
// description(item1 in order2) is:  pen
// description(item2 in order2) is:  box
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getitem()[0].getdescription()));
}
// price of item3 is200
// price of item4 is100
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getitem()[0].getprice()));
}
// iteamid for item3: 3
// iteamid for item4: 4
for (var i = 0; i < ordereditems.length; i++) {
    console.log("ordered quantity of item".concat(i + 1, ": ").concat(ordereditems[i].getitem()[0].getitemId()));
}
