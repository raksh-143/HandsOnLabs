//import the interface for Restaurant
import { RestaurantInfo } from "./RestaurantInfo";
//enum declaration
enum RestaurantType {'FastFood', 'Cafeteria', 'CoffeeHouse', 'Cafe', 'Bistros'};

//Declaraing Restaurant
let restaurant1: RestaurantInfo ={
    Name: 'Subway',
    Address: '#123/A Avenue',
    Phone: 9878987,
    Type: RestaurantType[RestaurantType.Cafe]
}

let RestaurantDetails = (rest: RestaurantInfo) =>{
    console.log('Name: '+ rest.Name + ' Address: '+ rest.Address + ' Phone: '+ 
    rest.Phone + 'Restaurant Type: '+ rest.Type)
}

RestaurantDetails(restaurant1);

//====================================================================
//Now lets have a list of restaurants
let restaurantList: RestaurantInfo[] = [
    {Name: 'Paradise',Address: '5th Block',Phone: 9778987,Type: RestaurantType[RestaurantType.FastFood]},
    {Name: 'MTR',Address: '12/16th Block, JP Nagar',Phone: 8878689,Type: RestaurantType[RestaurantType.Bistros]}
]
restaurantList.push(restaurant1);

//Function declaration
let GetRestaurantList = (restaurants: RestaurantInfo[]) =>{
    // restaurants.forEach(element => {
    //     console.log('Name: '+ element.Name + ' Address: '+ element.Address + 
    //     ' Phone: '+ element.Phone + ' Restaurant Type: '+ element.Type)
    // });

    //OR using anoynomous function
    restaurants.forEach(function(rst, index){
        console.log(`Restaurant ID: ${index+1} Name:${rst.Name}  Address:  ${rst.Address} 
        Phone: ${rst.Phone}  Restaurant Type: ${rst.Type}`);
    })
}

GetRestaurantList(restaurantList);