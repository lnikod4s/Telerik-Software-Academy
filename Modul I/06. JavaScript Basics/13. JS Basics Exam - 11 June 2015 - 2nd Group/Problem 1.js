function solve(params) {
	var nk = params[0].split(' ').map(Number),
		n = nk[0],
		k = nk[1],
		s = params[1].split(' ').map(Number),
		result = 0;
	
	function transformElement(num, left, right) {
		var result;

		if (num === 0) {
			result = Math.abs(left - right);
		} else if (num !== 0 && num % 2 === 0) {
			result = Math.max(left, right);
		} else if (num === 1) {
			result = left + right;
		} else if (num !== 1 && num % 2 === 1) {
			result = Math.min(left, right);
		}

		return result;
	}
	
	if (k === 0) {
		for (var i = 0; i < s.length; i += 1) {
			result += s[i];
		}

	} else {

		for (var j = 0; j < k; j += 1) {
			var tempArr = new Array(n);
			for (var m = 0; m < n; m += 1) {
				var currNum = s[m];
				var leftNeighbor = m === 0 ? s[n - 1] : s[m - 1];
				var rightNeighbor = m === n - 1 ? s[0] : s[m + 1];
				tempArr[m] = transformElement(currNum, leftNeighbor, rightNeighbor);
			}
			s = tempArr.slice();

		}

		for (var g = 0; g < n; g += 1) {
			result += tempArr[g];
		}
	}

	return result;
}

console.log(solve([
	'5 1',
	'9 0 2 4 1'
]));

console.log(solve([
	'10 3',
	'1 9 1 9 1 9 1 9 1 9'
]));

console.log(solve([
	'10 10',
	'0 1 2 3 4 5 6 7 8 9'
]));