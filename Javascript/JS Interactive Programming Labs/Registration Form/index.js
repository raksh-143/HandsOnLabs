function register(){
    let name = document.getElementById('name').value
    let pword = document.getElementById('pword').value
    let cpword = document.getElementById('cpword').value
    let sex = document.getElementById('sex').value
    if(name == '' || pword == '' || cpword == '' || sex == 0){
        document.getElementById('validationText').innerHTML = 'Enter all credentials'
    }
    else if(pword != cpword){
        document.getElementById('validationText').innerHTML = 'Passwords do not match'
    }
    else if(pword.length < 5){
        document.getElementById('validationText').innerHTML = 'Password should be at least 5 characters long'
    }
    else{
        document.getElementById('validationText').innerHTML = 'Registration successful'
        document.getElementById('pwordStrength').innerHTML = ''
        document.getElementById('pwordMatch').innerHTML = ''
        document.getElementById('name').value = ''
        document.getElementById('pword').value = ''
        document.getElementById('cpword').value = ''
        document.getElementById('sex').value = 0
        displaySymbol()
    }
}
function passwordStrength(){
    let pword = document.getElementById('pword').value
    if(pword.length < 5){
        document.getElementById('pwordStrength').innerHTML = 'Too Short'
    }
    else if(pword.length >= 5 && pword.length < 8){
        document.getElementById('pwordStrength').innerHTML = 'Weak'
    }
    else if(pword.length >= 8){
        document.getElementById('pwordStrength').innerHTML = 'Strong'
    }
    confirmPassword()
}
function confirmPassword(){
    let pword = document.getElementById('pword').value
    let cpword = document.getElementById('cpword').value
    if(pword == cpword){
        document.getElementById('pwordMatch').innerHTML = 'Passwords match'
    }
    else{
        document.getElementById('pwordMatch').innerHTML = 'Passwords do not match'
    }
}
function displaySymbol(){
    let sex = document.getElementById('sex').value
    if(sex == 0){
        document.getElementById('sexSymbol').src = ''
        document.getElementById('sexSymbol').style.display = 'none'   
    }
    else if(sex == 1){
        document.getElementById('sexSymbol').src = 'Male.png'
        document.getElementById('sexSymbol').style.display = 'block'   
    }
    else if(sex == 2){
        document.getElementById('sexSymbol').src = 'Female.png'
        document.getElementById('sexSymbol').style.display = 'block'   
    }
    else if(sex == 3){
        document.getElementById('sexSymbol').src = 'Others.jpg'
        document.getElementById('sexSymbol').style.display = 'block'      
    }
}