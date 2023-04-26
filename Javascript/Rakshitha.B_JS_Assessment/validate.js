function getMyFlight(){
    let output = `<div class="col g-col-3 text-center"><div class="card"><img src="logo.jpg" class="card-img-top" alt="Indigo Logo" width="180px" height="200px"><div class="card-body"><h5 class="card-title">${localStorage['myflightno']}</h5><p class="card-text">${localStorage['myfightdeets']}</p></div></div></div>`
    document.getElementById('flightSelected').innerHTML = output
}

function validateDetails(){
    let name = document.forms['myform']['name'].value
    let cardno = document.forms['myform']['cardno'].value
    let expdate = document.forms['myform']['expdate'].value
    let cvv = document.forms['myform']['cvv'].value
    if(name=="" || cardno =="" || expdate == "" || cvv ==""){
        alert('Enter all the credentials')
    }
    else{
        let dtregex = /^\d{2}\/\d{4}$/;
        if(!dtregex.test(expdate)){
            alert('Enter date in the correct format')
        }
        else{
            let [month,year] = expdate.split('/')
            let datexp = new Date(year,month-1,1)
            let curdate = new Date()
            if(datexp.getMonth() == curdate.getMonth() && datexp.getFullYear() == curdate.getFullYear()){
                alert('Card expired')
            }
            else{
                let cardnoregex = /^[0-9]{16}$/
                if(!cardnoregex.test(cardno)){
                    alert('Enter correct format for card number')
                }
                else{
                    let cvvregex = /^[0-9]{3}$/
                    if(!cvvregex.test(cvv)){
                        alert('Enter correct format for CVV/CVC')
                    }
                    else{
                        alert('Booking Confirmed')
                        document.forms['myform']['name'].value = ''
                        document.forms['myform']['cardno'].value = ''
                        document.forms['myform']['expdate'].value = ''
                        document.forms['myform']['cvv'].value = ''
                        location.href='index.html'
                    }
                }
            }
        }
    }
}