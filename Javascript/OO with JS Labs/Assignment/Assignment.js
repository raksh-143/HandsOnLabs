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
//Assignment
//Get all the customers in 'amazon' company
var customers = company.getCustomer();
for (var _i = 0, customers_1 = customers; _i < customers_1.length; _i++) {
    var customer = customers_1[_i];
    console.log(customer.getName());
}
//Get all the items available in 'amazon' company
var items = company.getitem();
for (var _a = 0, items_1 = items; _a < items_1.length; _a++) {
    var item_2 = items_1[_a];
    console.log(item_2.getdescription());
}
//Get the total quantity ordered for each item from the company with the total price
var totalQty = 0;
for (var _b = 0, customers_2 = customers; _b < customers_2.length; _b++) {
    var customer = customers_2[_b];
    var orders = customer.getorder();
    for (var _c = 0, orders_1 = orders; _c < orders_1.length; _c++) {
        var order_2 = orders_1[_c];
        var ordereditems = order_2.getorderitem();
        for (var _d = 0, ordereditems_1 = ordereditems; _d < ordereditems_1.length; _d++) {
            var ordereditem = ordereditems_1[_d];
            var qty = ordereditem.getquantity();
            totalQty += qty;
        }
    }
}
console.log(totalQty);
//Get the nteworth of the company
var networth = company.gettotaolworthoforders();
console.log(networth);
