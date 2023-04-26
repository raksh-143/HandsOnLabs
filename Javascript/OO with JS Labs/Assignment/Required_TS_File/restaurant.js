"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.restaurant = void 0;
var idgenerator_1 = require("./idgenerator");
var restaurant = /** @class */ (function () {
    function restaurant(_name) {
        this.item = [];
        this.customer = [];
        this.name = _name;
    }
    restaurant.prototype.getName = function () {
        return this.name;
    };
    restaurant.prototype.getcustomerId = function () {
        return idgenerator_1.IdGenerator.customerid++;
    };
    restaurant.prototype.getitem = function () {
        return this.item;
    };
    restaurant.prototype.getCustomer = function () {
        return this.customer;
    };
    restaurant.prototype.gettotaolworthoforders = function () {
        var networth = 0;
        for (var _i = 0, _a = this.getCustomer(); _i < _a.length; _i++) {
            var customer = _a[_i];
            for (var _b = 0, _c = customer.getorder(); _b < _c.length; _b++) {
                var order = _c[_b];
                for (var _d = 0, _e = order.getorderitem(); _d < _e.length; _d++) {
                    var item_1 = _e[_d];
                    networth += item_1.totalprice;
                }
            }
        }
        return networth;
    };
    return restaurant;
}());
exports.restaurant = restaurant;
