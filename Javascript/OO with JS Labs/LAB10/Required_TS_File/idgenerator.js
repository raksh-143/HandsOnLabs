"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.IdGenerator = void 0;
var IdGenerator = exports.IdGenerator = /** @class */ (function () {
    function IdGenerator() {
    }
    IdGenerator.getcustomerId = function () {
        return IdGenerator.customerid++;
    };
    IdGenerator.getorderId = function () {
        return IdGenerator.orderid++;
    };
    IdGenerator.getitemId = function () {
        return IdGenerator.itemid++;
    };
    IdGenerator.customerid = 1;
    IdGenerator.orderid = 1;
    IdGenerator.itemid = 1;
    return IdGenerator;
}());
