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
function isPrime(number):boolean{
    for(let i=2;i<=number/2;i++){
        if(number%i==0){
            return false
        }
    }
    return true
}
function getPairsWhoseDifferenceIsPrime(){
    let numbers:number[] = generateNumbers()
    let count:number = 0
    for(let i=0;i<numbers.length-1;i++){
        if(isPrime(Math.abs(numbers[i]-numbers[i+1]))){
            console.log(numbers[i]+" "+numbers[i+1])
            count++
        }
    }
    console.log(`Total Count: ${count}`)
}
getPairsWhoseDifferenceIsPrime();