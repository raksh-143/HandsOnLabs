function decimalToN(num:number,n:number):string{
    let nbasearray:string[] = ['0','1','2','3','4','5','6','7','8','9','A','B','C','D','E',
    'F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z']
    if(!(n>1 && n<=36)){
        return 'The divisor value should range from 1 to 36 only'
    }
    else{
        let tmp:number = num
        let result:string = ''
        while(tmp >= 1){
            let rem:number = tmp%n
            tmp  = Math.floor(tmp / n)
            result = nbasearray[rem] + result
        }
        return result
    }
}
console.log(decimalToN(718,12))
