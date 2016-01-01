// Write a function that returns the index of the first element in array that is bigger than its neighbors, or -1, if
// there’s no such element. Use the function from the previous exercise.

function solveTask(arr) {
	var hasFound = false;
	for (var i = 1; i < arr.length - 1; i++) {
		if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) {
			hasFound = true;
			return i;
		}
	}

	if (!hasFound) {
		return -1;
	}
}

console.log(solveTask([1, 2, 3, 4, 1, 2, 4, 2, 3, 1, 4, 2, 3, 2]));
console.log(solveTask([1, 1, 1, 1, 1]));