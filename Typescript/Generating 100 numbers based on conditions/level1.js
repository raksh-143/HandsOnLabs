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
    for (var _i = 0, resArray_1 = resArray; _i < resArray_1.length; _i++) {
        var myNum = resArray_1[_i];
        console.log(myNum);
    }
}
generateNumbers();
