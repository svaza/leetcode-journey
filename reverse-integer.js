"use strict";
function reverse(x) {
    let reverse = 0;
    let src = Math.abs(x);
    while (src > 0) {
        reverse += src % 10;
        src = Math.floor(src / 10);
        if (src > 0)
            reverse *= 10;
    }
    return reverse > Math.pow(2, 31) ? 0 : (x < 0 ? -reverse : reverse);
}
;
console.log(reverse(324));
console.log(reverse(12345));
console.log(reverse(120));
console.log(reverse(-1));
console.log(reverse(-987654321));
console.log(reverse(1563847412));
