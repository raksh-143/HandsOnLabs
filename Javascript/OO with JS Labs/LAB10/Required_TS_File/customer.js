"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Customer = void 0;
var idgenerator_1 = require("./idgenerator");
var Customer = /** @class */ (function () {
    function Customer(_name) {
        this.order = [];
        this.name = _name;
    }
    Customer.prototype.getName = function () {
        return this.name;
    };
    Customer.prototype.setName = function (_name) {
        this.name = _name;
    };
    Customer.prototype.getcustomerId = function () {
        return idgenerator_1.IdGenerator.customerid++;
    };
    Customer.prototype.getorder = function () {
        return this.order;
    };
    Customer.prototype.setOrder = function (_order) {
        this.order.push(_order);
    };
    return Customer;
}());
exports.Customer = Customer;
