// Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

function solveTask(number) {
	var message = 'The third bit of the given number is: ';
	if (number & (1 << 3) != 0) {
		console.log(message + 1);
	}
	else {
		console.log(message + 0);
	}
}

solveTask(3674);
solveTask(999);
solveTask(111);
solveTask(2730);