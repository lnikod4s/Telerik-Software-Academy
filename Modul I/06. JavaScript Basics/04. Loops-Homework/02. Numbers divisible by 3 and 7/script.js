// Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

function solveTask(number) {
	for (var i = 1; i <= number; i++) {
		if (i % 3 === 0 && i % 7 === 0) {
			console.log(i);
		}
	}

	console.log(new Array(11).join('-'));
}

solveTask(5);
solveTask(999);
solveTask(28713);