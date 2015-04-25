// Write an expression that checks if given integer is odd or even.

function solveTask(number) {
	if (number % 2 == 0) {
		return 'The number is even.';
	}
	else {
		return 'The number is odd.'
	}
}

console.log(solveTask(3));
console.log(solveTask(8));
console.log(solveTask(89));
console.log(solveTask(398902358285));
console.log(solveTask(238905725920));
console.log(solveTask(23764238));
console.log(solveTask(387578));