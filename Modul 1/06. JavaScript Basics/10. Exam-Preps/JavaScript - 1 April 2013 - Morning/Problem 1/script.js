function solve(params) {
	params = params.map(Number);

	for (var i = 2, count = 1; i < params.length; i++) {
		if (params[i] < params[i - 1]) {
			count++;
		}
	}

	return count;
}

console.log(solve([
	'7',
	'1',
	'2',
	'-3',
	'4',
	'4',
	'0',
	'1'
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
	'1',
	'8',
	'8',
	'7',
	'6',
	'5',
	'7',
	'7',
	'6'
]));