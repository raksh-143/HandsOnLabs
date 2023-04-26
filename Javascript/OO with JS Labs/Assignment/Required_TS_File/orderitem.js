"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.orderitem = void 0;
var orderitem = /** @class */ (function () {
    function orderitem(_quantity, item) {
        this.item = [];
        for (var _i = 0, item_1 = item; _i < item_1.length; _i++) {
            var items = item_1[_i];
            this.item.push(items);
            this.quantity = _quantity;
            this.totalprice = _quantity * items.getprice();
            break;
        }
    }
    orderitem.prototype.setquantity = function (_qty) {
        this.quantity = _qty;
    };
    orderitem.prototype.getquantity = function () {
        return this.quantity;
    };
    orderitem.prototype.getitem = function () {
        return this.item;
    };
    return orderitem;
}());
exports.orderitem = orderitem;
