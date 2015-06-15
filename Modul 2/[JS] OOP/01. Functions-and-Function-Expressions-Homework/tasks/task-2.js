/* Task description */
/*
 Write a function a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `string`
 3) it must throw an Error if any of the range params is missing
 */

function solve(start, end) {
	function isNumber(num) {
		return !isNaN(parseFloat(num)) && isFinite(num);
	}

	function isPrime(num) {
		var i = 2;
		if (num === 1) {
			return false;
		}

		if (num === 2) {
			return true;
		}

		while (i <= Math.sqrt(num)) {
			if (num % i === 0) {
				return false;
			}

			i += 1;
		}

		return true;
	}

	var result = [],
		i;

	if (arguments.length === 0 || arguments.length === 1) {
		throw new Error('Invalid range definition.');
	}

	if (!isNumber(start) || !isNumber(end)) {
		throw new Error('Range numbers must be convertible to Number.');
	}
	
	for (i = +start; i <= +end; i += 1) {
		var currNum = i;
		if (isPrime(currNum)) {
			result.push(currNum);
		}
	}
	
	return result;
}

module.exports = solve;