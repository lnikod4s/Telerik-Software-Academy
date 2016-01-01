// Sort 3 real values in descending order using nested if statements.

function solveTask(a, b, c) {
	if (a > b) {
		if (a > c) {
			if (b > c) {
				console.log('SortByDescending: ' + a + ', ' + b + ', ' + c);
			}
			else {
				console.log('SortByDescending: ' + a + ', ' + c + ', ' + b);
			}
		}
		else {
			console.log('SortByDescending: ' + c + ', ' + a + ', ' + b);
		}
	}
	else {
		if (b > c) {
			if (a > c) {
				console.log('SortByDescending: ' + b + ', ' + a + ', ' + c);
			}
			else {
				console.log('SortByDescending: ' + b + ', ' + c + ', ' + a);
			}
		}
		else {
			console.log('SortByDescending: ' + c + ', ' + b + ', ' + a);
		}
	}
}

solveTask(3, 4, 5);
solveTask(34, 35, 21);
solveTask(26, 13, 25);