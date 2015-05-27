function solve(params) {
	var N = parseInt(params[0]),
		maxSum = -2000000000,
		numbers = params.slice(1).map(Number);

	for (var i = 0; i < numbers.length; i++) {
		for (var j = i; j < numbers.length; j++) {
			var localSum = 0;
			for (var k = i; k <= j; k++) {
				localSum += numbers[k];
			}
			if (localSum > maxSum) {
				maxSum = localSum;
			}
		}
	}

	return maxSum;
}

console.log(solve([
	'8',
	'1',
	'6',
	'-9',
	'4',
	'4',
	'-2',
	'10',
	'-1'
]));

console.log(solve([
	'6',
	'1',
	'3',
	'-5',
	'8',
	'7',
	'-6'
]));

console.log(solve([
	'9',
	'-9',
	'-8',
	'-8',
	'-7',
	'-6',
	'-5',
	'-1',
	'-7',
	'-6'
]));

console.log(solve([
	'10',
	'1255569',
	'-851435',
	'1457629',
	'858237',
	'221970',
	'-652780',
	'1379095',
	'-732864',
	'-606100',
	'1566514'
]));