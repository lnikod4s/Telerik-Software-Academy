// Write a function that checks if the element at given position in given array of integers is bigger than its two
// neighbors (when such exist).

function solveTask(arr, pos) {
	if (pos <= 0 || pos >= arr.length - 1) {
		console.log("Please take another element's position.");
	}
	else {
		if (arr[pos] > arr[pos - 1] && arr[pos] > arr[pos + 1]) {
			console.log(true);
		}
		else {
			console.log(false);
		}
	}
}

solveTask([1, 2, 3, 4, 1, 2, 4, 2, 3, 1, 4, 2, 3, 2], 3);