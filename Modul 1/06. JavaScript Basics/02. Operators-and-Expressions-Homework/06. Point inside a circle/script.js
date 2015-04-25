// Write an expression that checks if given point (x, y) is within a circle K((0, 0), 5).

function solveTask(x, y) {
	return (x * x + y * y) < 5 * 5;
}

console.log(solveTask(3, 3));
console.log(solveTask(4, 3));
console.log(solveTask(4, 2));
console.log(solveTask(5, 1));