function solve(params) {
    var s = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
    var answer = 0;

    for (var count1 = 0; count1 <= (s / c1) + 1; count1++) {
        for (var count2 = 0; count2 <= (s / c2) + 1; count2++) {
            for (var count3 = 0; count3 <= (s / c3) + 1; count3++) {
                var price = (count1 * c1) + (count2 * c2) + (count3 * c3);
                if (price <= s) {
                    // if (price >= answer) console.log(s - price, i1, i2, i3);
                    answer = Math.max(answer, price);
                }
            }
        }
    }

    console.log(answer);
}
