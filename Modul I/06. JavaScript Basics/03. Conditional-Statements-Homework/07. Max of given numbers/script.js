// Write a script that finds the greatest of given 5 variables.

function solveTask(a, b, c, d, e) {
	var myArray = [a, b, c, d, e];
	myArray.sort();
	console.log(myArray[myArray.length - 1]);
}

solveTask(1, 2, 3, 4, 5);
solveTask(3, 1, 5, 8, 9);
solveTask(76, 45, 14, 47, 38);