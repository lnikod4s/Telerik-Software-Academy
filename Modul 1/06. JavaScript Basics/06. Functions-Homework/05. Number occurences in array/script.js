// Write a function that counts how many times given number appears in given array. Write a test function to check if
// the function is working correctly.

function solveTask(arr, num) {
	var answer = 0;
	for (var i = 0; i < arr.length; i++) {
		if (arr[i] === num) {
			answer++;
		}
	}

	return answer;
}

console.log(solveTask([1, 2, 3, 4, 1, 2, 4, 2, 3, 1, 4, 2, 3, 2], 2));