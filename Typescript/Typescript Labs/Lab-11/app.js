//Interfaces
//enum declaration
var RestaurantType;
(function (RestaurantType) {
    RestaurantType[RestaurantType["FastFood"] = 0] = "FastFood";
    RestaurantType[RestaurantType["Cafeteria"] = 1] = "Cafeteria";
    RestaurantType[RestaurantType["CoffeeHouse"] = 2] = "CoffeeHouse";
    RestaurantType[RestaurantType["Cafe"] = 3] = "Cafe";
    RestaurantType[RestaurantType["Bistros"] = 4] = "Bistros";
})(RestaurantType || (RestaurantType = {}));
;
//Declaring Restaurant using the contract
var Subway = /** @class */ (function () {
    function Subway() {
        this.Name = "Subway";
        this.Address = "#123/A Avenue";
        this.Phone = 9876543210;
        this.Type = "Cafe";
    }
    Subway.prototype.getDetails = function () {
        console.log(this.Name + " " + this.Address + " " + this.Phone + " " + this.Type);
    };
    return Subway;
}());
var MTR = /** @class */ (function () {
    function MTR() {
        this.Name = "MTR";
        this.Address = "#123/A Avenue";
        this.Phone = 9876543210;
        this.Type = "Fast Food";
    }
    MTR.prototype.getDetails = function () {
        console.log(this.Name + " " + this.Address + " " + this.Phone + " " + this.Type);
    };
    return MTR;
}());
var Paradise = /** @class */ (function () {
    function Paradise() {
        this.Name = "Paradise";
        this.Address = "#123/A Avenue";
        this.Phone = 9876543210;
        this.Type = "Bistros";
    }
    Paradise.prototype.getDetails = function () {
        console.log(this.Name + " " + this.Address + " " + this.Phone + " " + this.Type);
    };
    return Paradise;
}());
var restArray = [];
var rest1 = new Subway();
restArray.push(rest1);
var rest2 = new MTR();
restArray.push(rest2);
var rest3 = new Paradise();
restArray.push(rest3);
//Modify the function RestaurantDetails to accepts a type of the contract defined, to view the restaurant details.
var RestaurantDetails = function (restArray) {
    //display the restaurant details
    console.log('Name:  Address:  Phone:  Restaurant Type:');
    restArray.forEach(function (item) {
        item.getDetails();
    });
};
//call the function to view the result
RestaurantDetails(restArray);
