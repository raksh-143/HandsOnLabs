let tasks = []
let tasksCount = 0
function addTask(){
    var task = document.getElementById('taskEntry').value;
    if(task == ''){
        alert('Enter some text to add a task.')
    }
    else{
        tasks[tasksCount] = task;
        tasksCount++;
        alert('Task added successfully.')
        document.getElementById('taskEntry').value = ""
    }
}
function displayTasks(){
    output = '<ul>'
    for(let i=0;i<tasksCount;i++){
        if(tasks[i] != null){
            output+=`<li><span>${tasks[i]}</span><input type='button' onclick='deleteTasks(${i})' value='Delete'/></li>`
        }
    }
    output+='</ul>'
    document.getElementById('allTasks').innerHTML = output
}
function deleteTasks(id){
    tasks[id] = null
    alert('Task deleted successfully')
    displayTasks()
}