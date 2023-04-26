var cars = null;
function loadCars(){
    fetch('Cars.json')
    .then(response => response.json())
    .then(data => {
        cars = data.cars;
        let output = '<div class="row">'
        cars.forEach(car => {
            output += `<div class="col-lg-4 mt-5"><div class="card" style="width: 18rem;"><img src="..." class="card-img-top" alt="..."><div class="card-body"><h5 class="card-title">${car.name}</h5><p class="card-text">Model: ${car.model}<br/>Price: ${car.price}<br/>Usage Info: ${car.usage_info}<br/>Brand: ${car.brand}<br/>Fuel Type: ${car.fuel_type}</p></div></div></div>`
        });
        output+='</div>'
        document.getElementById('carsForDisplay').innerHTML = output
    })
    .catch(error => {
        console.error('Error loading cars data:', error);
    });
}
function AddFilterBasedOnBrand(){

}
function RemoveFilterBasedOnBrand(){

}
function filterBasedOnPrice(){
    document.getElementById('priceSliderValue').innerHTML = document.getElementById('priceSlider').value
    let price = document.getElementById('priceSlider').value
    fetch('Cars.json')
    .then(response => response.json())
    .then(data => {
        cars = data.cars;
        let output = '<div class="row">'
        cars.forEach(car => {
            if(car.price<=price){
                output += `<div class="col-lg-4 mt-5"><div class="card" style="width: 18rem;"><img src="..." class="card-img-top" alt="..."><div class="card-body"><h5 class="card-title">${car.name}</h5><p class="card-text">Model: ${car.model}<br/>Price: ${car.price}<br/>Usage Info: ${car.usage_info}<br/>Brand: ${car.brand}<br/>Fuel Type: ${car.fuel_type}</p></div></div></div>`
            }
        });
        output+='</div>'
        document.getElementById('carsForDisplay').innerHTML = output
    })
    .catch(error => {
        console.error('Error loading cars data:', error);
    });
}
function AddfilterBasedOnFuelType(){
    fetch('Cars.json')
    .then(response => response.json())
    .then(data => {
        cars = data.cars;
        let output = '<div class="row">'
        cars.forEach(car => {
            output += `<div class="col-lg-4 mt-5"><div class="card" style="width: 18rem;"><img src="..." class="card-img-top" alt="..."><div class="card-body"><h5 class="card-title">${car.name}</h5><p class="card-text">Model: ${car.model}<br/>Price: ${car.price}<br/>Usage Info: ${car.usage_info}<br/>Brand: ${car.brand}<br/>Fuel Type: ${car.fuel_type}</p></div></div></div>`
        });
        output+='</div>'
        document.getElementById('carsForDisplay').innerHTML = output
    })
    .catch(error => {
        console.error('Error loading cars data:', error);
    });
}