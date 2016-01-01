// Write a script that finds the maximal increasing sequence in an array.

function solveTask(arr) {
	var currentL = 1, maxL = 0, lastIndex = 0;
	for (var i = 1; i < arr.length; i++) {
		if (arr[i - 1] < arr[i]) {
			currentL++;
		}
		else {
			if (maxL < currentL) {
				maxL = currentL;
				currentL = 1;
				lastIndex = i;
			}
		}
	}

	if (maxL < currentL) {
		maxL = currentL;
		lastIndex = arr.length;
	}

	var resultsStr = "Maximal increasing sequence : ";
	for (var j = 0; j < maxL; j++) {
		resultsStr += arr[lastIndex - maxL + j];
		resultsStr += ' ';
	}

	console.log(resultsStr);
}

solveTask([3, 2, 3, 4, 2, 2, 4, 5, 6, 7]);
solveTask([1, 2, 3, 16, 17, 18, 19]);