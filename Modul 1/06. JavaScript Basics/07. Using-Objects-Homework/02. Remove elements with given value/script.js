/*Write a function that removes all elements with a given value
 ```js
 var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
 arr.remove(1); // arr = [2, 4, 3, 4, 111, 3, 2, "1"];
 ```
 * Attach it to the array object
 * Read about `prototype` and how to attach methods
 * */

function solveTask(arr, element) {
	Array.prototype.remove = function (element) {
		for (var i = 0; i < this.length; i++) {
			if (this[i] === element) {
				this.splice(i, 1);
				i--;
			}
		}
	};

	for (var i = 0; i < arr.length; i++) {
		console.log(arr[i] + " type is " + typeof arr[i]);
	}

	arr.remove(1);

	for (var j = 0; j < arr.length; j++) {
		console.log(arr[j] + " type is " + typeof arr[j]);
	}
}

solveTask([1, 2, 1, 4, 1, 1, 1, 1, 3, 4, 1, 1, 111, 3, 2, 1, '1']);