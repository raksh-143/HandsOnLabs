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
function getNegativeNumbersWith3() {
    var numbers = generateNumbers();
    var myResArray = [];
    for (var _i = 0, numbers_1 = numbers; _i < numbers_1.length; _i++) {
        var eachNum = numbers_1[_i];
        if (eachNum < 0) {
            var eachNumStr = "".concat(eachNum);
            if (eachNumStr.indexOf('3') != -1) {
                myResArray.push(eachNum);
            }
        }
    }
    console.log("Total Numbers: ".concat(myResArray.length));
    for (var _a = 0, myResArray_1 = myResArray; _a < myResArray_1.length; _a++) {
        var num = myResArray_1[_a];
        console.log(num);
    }
}
getNegativeNumbersWith3();
