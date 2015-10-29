/* Task Description */
/*
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined)
 throws if any of the elements is not convertible to Number
 */

function solve(arr) {
	function isNumber(num) {
		return !isNaN(parseFloat(num)) && isFinite(num);
	}

	function hasNumericValues(arr) {
		return arr.every(isNumber);
	}

	if (arguments.length === 0) {
		throw new Error('The function has no parameters.');
	}

	if (!hasNumericValues(arr)) {
		throw new Error('Every array element must be convertible to Number.');
	}

	if (arr.length === 0) {
		return null;
	}

	return arr.map(Number)
		.reduce(function(previous, current) {
			        return previous + current;
		        });
}

module.exports = solve;