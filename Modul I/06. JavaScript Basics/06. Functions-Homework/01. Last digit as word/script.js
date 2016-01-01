// Write a function that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024 ->
// "four", 12309 -> "nine"

function solveTask(number) {
	var lastDigit = number % 10;
	switch (lastDigit) {
		case 0:
			console.log('zero');
			break;
		case 1:
			console.log('one');
			break;
		case 2:
			console.log('two');
			break;
		case 3:
			console.log('three');
			break;
		case 4:
			console.log('four');
			break;
		case 5:
			console.log('five');
			break;
		case 6:
			console.log('six');
			break;
		case 7:
			console.log('seven');
			break;
		case 8:
			console.log('eight');
			break;
		case 9:
			console.log('nine');
			break;
		default:
			console.log('Error!');
			break;
	}
}

solveTask(512);
solveTask(1024);
solveTask(12309);