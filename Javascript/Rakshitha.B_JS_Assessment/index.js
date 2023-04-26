class flight{
    constructor(flightno,deptdt,depttime,arrdt,from,to){
        this.flightno = flightno
        this.deptdt = deptdt
        this.depttime = depttime
        this.arrdt = arrdt
        this.from = from
        this.to = to
    }
    getDetails(){
        let details = `Departure Date: ${this.deptdt}<br/>Departure Time: ${this.depttime}<br/>Arrival Date: ${this.arrdt}<br/>From: ${this.from}<br/>To: ${this.to}`
        return [this.flightno,details]
    }
}

let selectedFlight = {
    flightno: null,
    details: null
}

let f1 = new flight('66E5','3rd June 2023','3:30pm','3rd June 5:45pm','Bangalore','Delhi')
let f2 = new flight('64D9','5th June 2023','5:00pm','5th June 8:45pm','Bangalore','Punjab')
let f3 = new flight('72N3','1st April 2023','6:00am','1st April 8:00am','Bangalore','Mumbai')
let f4 = new flight('62N4','29th June 2023','4:20pm','29th June 7:00am','Bangalore','Assam')

function loadFlights(){
    let output = '<div class="grid text-center container-fluid"><div class="row">'
    for(let f of [f1,f2,f3,f4]){
        let details = f.getDetails()
        output += `<div class="col g-col-3 g-col-md-4"><div class="card"><img src="logo.jpg" class="card-img-top" alt="Indigo Logo" width="180px" height="200px"><div class="card-body"><h5 class="card-title">${details[0]}</h5><p class="card-text">${details[1]}</p><button type="button" id="${details[0]},${details[1]}" onclick="flightSelected(this.id);" class="btn btn-primary">Book Now!</button></div></div></div>`
    }
    output+='</div></div>' 
    document.getElementById('flights').innerHTML = output
}

function flightSelected(id){
    let myFlight = id.split(',')
    selectedFlight.flightno = myFlight[0]
    selectedFlight.details = myFlight[1]
    localStorage['myflightno'] = selectedFlight.flightno
    localStorage['myfightdeets'] = selectedFlight.details
    location.href='paymentInfo.html'
}