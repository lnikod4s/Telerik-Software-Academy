function solve(params) {
	var N = Number(params[0]),
		count = 1,
		last = Number(params[1]),
		current,
		i;

	for (i = 2; i <= N; i++) {
		current = Number(params[i]);
		if (current < last) count++;
		last = current;
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