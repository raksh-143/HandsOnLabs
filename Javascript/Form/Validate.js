function validate(){
    var emailEntered = document.forms["myform"]["email"].value
    var phoneEntered = document.forms["myform"]["phone"].value
    var pwordEntered = document.forms["myform"]["password"].value
    var flag = 0;

    if(emailEntered=="" || phoneEntered == "" || pwordEntered == ""){
        alert('Enter all the credentials!');
        flag=1
    }
    else{
        var emailRegex = /^\S+@\S+\.\S+$/
        if(!emailRegex.test(emailEntered)){
            alert('Email not in proper format!');
            flag=1
        }
        else{
            var phoneregex = /^\+91[0-9]{10}/;
            if(!phoneregex.test(phoneEntered)){
                alert('Phone number not in proper format!');
                flag=1
            }
            else{
                var pwordregex = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,12}$/
                if(!pwordregex.test(pwordEntered)){
                    alert('Password not as per the guidelines!');
                    flag=1
                }
            }
        }
    }
    if(flag == 0){
        alert('You have registered successfully!')
        document.forms["myform"]["email"].value = ''
        document.forms["myform"]["phone"].value = ''
        document.forms["myform"]["password"].value = ''
    }
}