function Solve(params) {
	var N = parseInt(params[0]);
	var count = 1;
	var last = parseInt(params[1]);
	for (var i = 2; i <= N; i++) {
		var current = parseInt(params[i]);
		if (current < last) {
			count++;
		}
		last = current;
	}
	return count;
}
