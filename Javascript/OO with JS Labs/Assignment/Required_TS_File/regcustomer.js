"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.RegCustomer = void 0;
var customer_1 = require("./customer");
var RegCustomer = /** @class */ (function (_super) {
    __extends(RegCustomer, _super);
    function RegCustomer(name, discount) {
        var _this = _super.call(this, name) || this;
        _this.discount = discount;
        return _this;
    }
    RegCustomer.prototype.getDiscount = function () {
        return this.discount;
    };
    RegCustomer.prototype.setDiscount = function (discount) {
        this.discount = discount;
    };
    return RegCustomer;
}(customer_1.Customer));
exports.RegCustomer = RegCustomer;
