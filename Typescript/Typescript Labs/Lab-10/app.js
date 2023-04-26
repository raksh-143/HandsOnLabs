//Interfaces
//enum declaration
//Define enum RestaurantType to store the type of restaurants
var RestaurantType;
(function (RestaurantType) {
    RestaurantType[RestaurantType["Cafe"] = 0] = "Cafe";
    RestaurantType[RestaurantType["Dining"] = 1] = "Dining";
    RestaurantType[RestaurantType["FastFood"] = 2] = "FastFood";
})(RestaurantType || (RestaurantType = {}));
//Declaring Restaurant using the contract
var Restaurant = /** @class */ (function () {
    function Restaurant() {
        this.Name = "Subway";
        this.Address = "#123/A Avenue";
        this.Phone = 9876543210;
        this.Type = "Cafe";
    }
    Restaurant.prototype.getDetails = function () {
        console.log(this.Name + " " + this.Address + " " + this.Phone + " " + this.Type);
    };
    return Restaurant;
}());
//Modify the function RestaurantDetails to accepts a type of the contract defined, to view the restaurant details.
var RestaurantDetails = function () {
    //display the restaurant details
    console.log('Name:  Address:  Phone:  Restaurant Type:');
};
//call the function to view the result
var rest = new Restaurant();
RestaurantDetails();
rest.getDetails();
