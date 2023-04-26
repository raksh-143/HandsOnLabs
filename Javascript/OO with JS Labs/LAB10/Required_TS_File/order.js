"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.order = void 0;
var idgenerator_1 = require("./idgenerator");
var order = /** @class */ (function () {
    function order() {
        this.orderitem = [];
        this.orderid = idgenerator_1.IdGenerator.getorderId();
    }
    order.prototype.getOrderid = function () {
        return this.orderid;
    };
    order.prototype.getorderitem = function () {
        return this.orderitem;
    };
    order.prototype.setOrderItem = function (_orderItem) {
        this.orderitem.push(_orderItem);
    };
    return order;
}());
exports.order = order;
