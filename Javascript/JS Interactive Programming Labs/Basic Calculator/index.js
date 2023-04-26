function calculate(operator){
    document.getElementById('operator').innerHTML = operator
    var num1 = parseInt(document.getElementById('num1').value)
    var num2 = parseInt(document.getElementById('num2').value)
    var res = 0
    if(operator == '+'){
        res = num1+num2
    }
    else if(operator == '-'){
        res = num1-num2
    }
    else if(operator == 'x'){
        res = num1*num2
    }
    else if(operator == '/'){
        res = num1/num2
    }
    document.getElementById('result').value = res
}