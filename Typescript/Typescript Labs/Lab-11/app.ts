//Interfaces

//enum declaration
enum RestaurantType {'FastFood', 'Cafeteria', 'CoffeeHouse', 'Cafe', 'Bistros'};

//Restaurant Interface declaration
interface IRestaurant{
    Name: string,
    Address: string,
    Phone: Number,
    Type: string
}

//Declaring Restaurant using the contract
class Subway implements IRestaurant{
    Name  = "Subway"
    Address = "#123/A Avenue"
    Phone = 9876543210
    Type = "Cafe"
    getDetails(){
        console.log(this.Name+" "+this.Address+" "+this.Phone+" "+this.Type)
    }
}
class MTR implements IRestaurant{
    Name  = "MTR"
    Address = "#123/A Avenue"
    Phone = 9876543210
    Type = "Fast Food"
    getDetails(){
        console.log(this.Name+" "+this.Address+" "+this.Phone+" "+this.Type)
    }
}

class Paradise implements IRestaurant{
    Name  = "Paradise"
    Address = "#123/A Avenue"
    Phone = 9876543210
    Type = "Bistros"
    getDetails(){
        console.log(this.Name+" "+this.Address+" "+this.Phone+" "+this.Type)
    }
}

let restArray:IRestaurant[] = []
let rest1:Subway = new Subway()
restArray.push(rest1)
let rest2:MTR = new MTR()
restArray.push(rest2)
let rest3:Paradise = new Paradise()
restArray.push(rest3)

//Modify the function RestaurantDetails to accepts a type of the contract defined, to view the restaurant details.
let RestaurantDetails = (restArray) =>{
	//display the restaurant details
    console.log('Name:  Address:  Phone:  Restaurant Type:')
    restArray.forEach(function(item){
        item.getDetails()  
    })
}

//call the function to view the result
RestaurantDetails(restArray)
