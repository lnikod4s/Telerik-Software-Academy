// Write an if statement that examines two integer variables and exchanges their values if the first one is greater
// than the second one.

function solveTask(a, b) {
	console.log('Initial values: a = ' + a + ', b = ' + b);
	console.log('Is the first one greater than the second one? --> ' + (a > b));
	if (a > b) {
		a ^= b;
		b ^= a;
		a ^= b;
		console.log('After swapping: a = ' + a + ', b = ' + b);
	}
}

solveTask(3, 2);
solveTask(55, 56);
solveTask(3674673, 938493);