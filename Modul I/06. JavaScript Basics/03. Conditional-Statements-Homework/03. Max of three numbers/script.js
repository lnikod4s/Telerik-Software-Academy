// Write a script that finds the biggest of three integers using nested if statements.

function solveTask(a, b, c) {
	if (a > b) {
		if (a > c) {
			console.log(a);
		}
		else {
			console.log(c);
		}
	}
	else {
		if (b > c) {
			console.log(b);
		}
		else {
			console.log(c);
		}
	}
}

solveTask(3, 4, 5);
solveTask(34, 35, 21);
solveTask(26, 13, 25);