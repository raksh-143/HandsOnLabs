function generateNumbers():number[]{
    let count:number = 0
    let num:number = 9
    let resArray:number[] = []
    while(count != 100){
        if(num%9 == 0){
            let tmpNum:string = `${num}`
            if(tmpNum.length >= 2){
                let a:number = parseInt(tmpNum[tmpNum.length-1])
                let b:number = parseInt(tmpNum[tmpNum.length-2])
                if(Math.abs(a-b) == 3){
                    resArray.push(num*-1)
                }else{
                    resArray.push(num)
                }
            }
            else{
                resArray.push(num)
            }
            count++
        }
        num++
    }
    // for(let myNum of resArray){
    //     console.log(myNum)
    // }
    return resArray
}
function getNegativeNumbersWith3(){
    let numbers:number[] = generateNumbers()
    let myResArray:number[] = []
    for(let eachNum of numbers){
        if(eachNum<0){
            let eachNumStr:string = `${eachNum}`
            if(eachNumStr.indexOf('3') != -1){
                myResArray.push(eachNum)
            }
        }
    }
    console.log(`Total Numbers: ${myResArray.length}`)
    for(let num of myResArray){
        console.log(num)
    }
}
getNegativeNumbersWith3();