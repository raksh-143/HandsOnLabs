const add = () => {
    var a = parseInt(document.getElementById('number1').value)
    var b = parseInt(document.getElementById('number2').value)
    document.getElementById('output').value = a+b
}
const sub = () => {
    var a = parseInt(document.getElementById('number1').value)
    var b = parseInt(document.getElementById('number2').value)
    document.getElementById('output').value = a-b
}
const mul = () => {
    var a = parseInt(document.getElementById('number1').value)
    var b = parseInt(document.getElementById('number2').value)
    document.getElementById('output').value = a*b
}
const div = () => {
    var a = parseInt(document.getElementById('number1').value)
    var b = parseInt(document.getElementById('number2').value)
    document.getElementById('output').value = a/b
}