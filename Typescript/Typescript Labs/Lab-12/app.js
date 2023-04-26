"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
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
//Declaraing Restaurant
var restaurant1 = {
    Name: 'Subway',
    Address: '#123/A Avenue',
    Phone: 9878987,
    Type: RestaurantType[RestaurantType.Cafe]
};
var RestaurantDetails = function (rest) {
    console.log('Name: ' + rest.Name + ' Address: ' + rest.Address + ' Phone: ' +
        rest.Phone + 'Restaurant Type: ' + rest.Type);
};
RestaurantDetails(restaurant1);
//====================================================================
//Now lets have a list of restaurants
var restaurantList = [
    { Name: 'Paradise', Address: '5th Block', Phone: 9778987, Type: RestaurantType[RestaurantType.FastFood] },
    { Name: 'MTR', Address: '12/16th Block, JP Nagar', Phone: 8878689, Type: RestaurantType[RestaurantType.Bistros] }
];
restaurantList.push(restaurant1);
//Function declaration
var GetRestaurantList = function (restaurants) {
    // restaurants.forEach(element => {
    //     console.log('Name: '+ element.Name + ' Address: '+ element.Address + 
    //     ' Phone: '+ element.Phone + ' Restaurant Type: '+ element.Type)
    // });
    //OR using anoynomous function
    restaurants.forEach(function (rst, index) {
        console.log("Restaurant ID: ".concat(index + 1, " Name:").concat(rst.Name, "  Address:  ").concat(rst.Address, " \n        Phone: ").concat(rst.Phone, "  Restaurant Type: ").concat(rst.Type));
    });
};
GetRestaurantList(restaurantList);
