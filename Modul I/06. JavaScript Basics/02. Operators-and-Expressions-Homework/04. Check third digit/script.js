// Write an expression that checks for given integer if its third digit (right-to-left) is 7.

function solveTask(number) {
	return Math.floor(number / 100) % 10 == 7;
}

console.log(solveTask(32874389789));
console.log(solveTask(654637890));
console.log(solveTask(367889374756));
console.log(solveTask(2535712));