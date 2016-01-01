// Write a program that finds the most frequent number in an array.

function solveTask(arr) {
	var maxL = 0;
	var element = arr[0];
	for (var i = 0; i < arr.length; i++) {
		var currL = 0;
		for (var j = 0; j < arr.length; j++) {
			if (arr[i] === arr[j]) {
				currL++;
			}
		}

		if (currL > maxL) {
			maxL = currL;
			element = arr[i];
		}
	}

	console.log('Most frequent number: ' + element);
}

solveTask([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);