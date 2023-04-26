"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.item = void 0;
var idgenerator_1 = require("./idgenerator");
var item = /** @class */ (function () {
    function item(_price, _description) {
        this.price = _price;
        this.descripion = _description;
    }
    item.prototype.getitemId = function () {
        return idgenerator_1.IdGenerator.itemid++;
    };
    item.prototype.getprice = function () {
        return this.price;
    };
    item.prototype.getdescription = function () {
        return this.descripion;
    };
    return item;
}());
exports.item = item;
