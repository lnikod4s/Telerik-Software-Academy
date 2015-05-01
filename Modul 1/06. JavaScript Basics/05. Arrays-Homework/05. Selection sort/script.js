// Sorting an array means to arrange its elements in increasing order. Write a script to sort an array. Use the
// **"selection sort"** algorithm: Find the smallest element, move it at the first position, find the smallest from the
// rest, move it at the second position, etc. Hint: Use a second array

function solveTask(arr) {
	for (var i = 0; i < arr.length; i++) {
		var currMin = i;
		for (var j = i + 1; j < arr.length; j++) {
			if (arr[currMin] > arr[j]) {
				currMin = j;
			}
		}
		var helper = arr[i];
		arr[i] = arr[currMin];
		arr[currMin] = helper;
	}

	console.log(arr.join(', '));
}

solveTask([4, 3, 6, 8, 9, 2, 11, 0, -4, -2, 18]);