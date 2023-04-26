function mouseover(){
    document.getElementById('hover').style.backgroundColor='#d63384';
    document.getElementById('hover').style.color='white';
}
function mouseout(id){
    document.getElementById(id).style.backgroundColor='black';
    document.getElementById(id).style.color='white';
}
function clicking(){
    document.getElementById('click').style.backgroundColor='#dc3545';
}
function dblclicking(){
    document.getElementById('dblclicking').style.backgroundColor='#0d6efd';
}
function nocopy(){
    alert("Cannot copy this text!");
}