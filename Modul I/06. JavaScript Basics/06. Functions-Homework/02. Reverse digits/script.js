// Write a function that reverses the digits of given decimal number. Example: 256 -> 652

function solveTask(number) {
	for(var r = 0; number; number = Math.floor(number / 10)) {
		r *= 10;
		r += number % 10;
	}

	console.log(r);
}

solveTask(256);