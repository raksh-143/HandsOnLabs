function generateNumbers() {
    var count = 0;
    var num = 9;
    var resArray = [];
    while (count != 100) {
        if (num % 9 == 0) {
            var tmpNum = "".concat(num);
            if (tmpNum.length >= 2) {
                var a = parseInt(tmpNum[tmpNum.length - 1]);
                var b = parseInt(tmpNum[tmpNum.length - 2]);
                if (Math.abs(a - b) == 3) {
                    resArray.push(num * -1);
                }
                else {
                    resArray.push(num);
                }
            }
            else {
                resArray.push(num);
            }
            count++;
        }
        num++;
    }
    // for(let myNum of resArray){
    //     console.log(myNum)
    // }
    return resArray;
}
function isPrime(number) {
    for (var i = 2; i <= number / 2; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
}
function getPairsWhoseDifferenceIsPrime() {
    var numbers = generateNumbers();
    var count = 0;
    for (var i = 0; i < numbers.length - 1; i++) {
        if (isPrime(Math.abs(numbers[i] - numbers[i + 1]))) {
            console.log(numbers[i] + " " + numbers[i + 1]);
            count++;
        }
    }
    console.log("Total Count: ".concat(count));
}
getPairsWhoseDifferenceIsPrime();
