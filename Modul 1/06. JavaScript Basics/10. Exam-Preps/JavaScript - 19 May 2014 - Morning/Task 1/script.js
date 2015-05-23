function solve(params) {
	var s = parseInt(params[0]);
	var count = 0;
	var c1 = 4, c2 = 10, c3 = 3;

	for (var i = 0; i <= s; i++) {
		for (var j = 0; j <= s; j++) {
			for (var k = 0; k <= s; k++) {
				var currCount = (i * c1) + (j * c2) + (k * c3);
				if(currCount > s) break;
				if(currCount == s) count++;
			}
		}
	}

	return count;
}

console.log(solve([7]));
console.log(solve([10]));
console.log(solve([40]));