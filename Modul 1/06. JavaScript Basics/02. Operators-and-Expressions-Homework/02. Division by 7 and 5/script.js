// Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5
// in the same time.

function solveTask(number) {
	if (number % 7 == 0 && number % 5 == 0) {
		return 'The given number can be divided (without remainder) by 7 AND 5.';
	}
	else {
		return 'The given number cannot be divided by 7 AND 5.'
	}
}

console.log(solveTask(35));
console.log(solveTask(5));
console.log(solveTask(7));
console.log(solveTask(21));
console.log(solveTask(175));