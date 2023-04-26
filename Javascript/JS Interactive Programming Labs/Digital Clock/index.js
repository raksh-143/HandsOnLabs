function startClock(){
    window.setInterval(function(){
        updateClock()
    },1000)
}
function updateClock(){
    var date = new Date();
    var hour = date.getHours();
    var min = date.getMinutes();
    var sec = date.getSeconds();
    document.getElementById('display').innerHTML = `${hour}:${min}:${sec}`
}