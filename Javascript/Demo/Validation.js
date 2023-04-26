function validate(){
    var emailEntered = document.forms["form"]["email"].value
    var emailRegex = /^\S+@\S+\.\S+$/
    if(!emailRegex.test(emailEntered)){
        alert('Email not in proper format')
    }
}