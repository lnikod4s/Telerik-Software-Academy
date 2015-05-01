// Write a program that finds the index of given element in a sorted array of integers by using the binary search
// algorithm.

function solveTask(arr, element) {
	var min = 0, max = arr.length - 1, answer = -1;
	while (min <= max) {
		var mid = min + (max - min) / 2;
		mid = Math.floor(mid);
		if (arr[mid] > element) {
			max = mid - 1;
		}
		else if (arr[mid] < element) {
			min = mid + 1;
		}
		else {
			answer = mid;
			break;
		}
	}
	
	console.log('Index of element ' + element + ' is ' + answer);
}

solveTask([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 4);
solveTask([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 9);
solveTask([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 5);