//Create an array 'foodItems' 
var foodItems = ["Sandwich", "Pizza", 'Pasta', 'Salad', 'Pancake', 'Rice', 'Ice Cream'];
//sample function
function sayHello(foodItem) {
    console.log((foodItems.indexOf(foodItem) + 1) + ". " + foodItem);
}
//Update the forEach to print the Sl No and items
//Example:
//1. Sandwich
//2. Pizza
foodItems.forEach(function (foodItem) {
    sayHello(foodItem);
});
