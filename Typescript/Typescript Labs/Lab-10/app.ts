//Interfaces

//enum declaration
//Define enum RestaurantType to store the type of restaurants
enum RestaurantType{
    Cafe,
    Dining,
    FastFood
}

//Restaurant Interface declaration
interface IRestaurant{
    Name:string,
    Address:string,
    Type:string,
    Phone:number
}

//Declaring Restaurant using the contract
class Restaurant implements IRestaurant{
    Name  = "Subway"
    Address = "#123/A Avenue"
    Phone = 9876543210
    Type = "Cafe"
    getDetails(){
        console.log(this.Name+" "+this.Address+" "+this.Phone+" "+this.Type)
    }
}

//Modify the function RestaurantDetails to accepts a type of the contract defined, to view the restaurant details.
let RestaurantDetails = () =>{
	//display the restaurant details
    console.log('Name:  Address:  Phone:  Restaurant Type:')
}

//call the function to view the result
let rest:Restaurant = new Restaurant()
RestaurantDetails()
rest.getDetails()
