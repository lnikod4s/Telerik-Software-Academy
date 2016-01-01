// Write a script that prints all the numbers from 1 to N.

function solveTask(number) {
	for (var i = 1; i <= number; i++) {
		console.log(i);
	}

	console.log(new Array(11).join('-'));
}

solveTask(5);
solveTask(999);
solveTask(28713);