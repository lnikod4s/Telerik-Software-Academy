// Write a script that enters the coefficients a, b and c of a quadratic equation a*x2 + b*x + c = 0

function solveTask(a, b, c) {
	var d = b * b - 4 * a * c;

	if (a === 0) {
		console.log('x = ' + (-c / b));
	}
	else {
		if (d < 0) {
			console.log('no real roots');
		}
		else if (d === 0) {
			console.log('x1 = x2 = ' + ((-b) / (2 * a)));
		}
		else {
			console.log('x1 = ' + ((-b - Math.sqrt(d))) / (2 * a));
			console.log('x2 = ' + ((-b + Math.sqrt(d))) / (2 * a));
		}
	}
}

solveTask(2, 5, -3);
solveTask(-1, 3, 0);
solveTask(-0.5, 4, -8);
solveTask(5, 2, 8);