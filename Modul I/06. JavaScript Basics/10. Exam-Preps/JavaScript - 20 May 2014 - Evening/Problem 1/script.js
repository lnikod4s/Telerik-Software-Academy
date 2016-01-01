function solve(params) {
	var s = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
	var answer = 0, currAnswer;
	var upperBorder = function findUpperBorder(total, part) {
		return (total / part) + 1;
	};

	for (var i = 0; i <= upperBorder(s, c1); i++) {
		for (var j = 0; j <= upperBorder(s, c2); j++) {
			for (var k = 0; k <= upperBorder(s, c3); k++) {
				currAnswer = (i * c1) + (j * c2) + (k * c3);
				if (currAnswer > s) break;
				if (currAnswer <= s) answer = Math.max(answer, currAnswer);
			}
		}
	}

	return answer;
}

console.log(solve([110, 13, 15, 17]));
console.log(solve([20, 11, 200, 300]));
console.log(solve([110, 19, 29, 39]));