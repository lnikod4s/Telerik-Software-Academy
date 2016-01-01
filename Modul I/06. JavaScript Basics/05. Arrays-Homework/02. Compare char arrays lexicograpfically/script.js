// Write a script that compares two char arrays lexicographically (letter by letter).

function solveTask(n, m) {
	var firstArr = randomString(n);
	var secondArr = randomString(m);
	var length = Math.min(firstArr.length, secondArr.length);

	if (firstArr.length > secondArr.length) {
		console.log('Second array is earlier.');
	}
	else if (firstArr.length == secondArr.length) {
		for (var i = 0; i < length; i++) {
			if (firstArr[i] > secondArr[i]) {
				console.log('Second array is earlier.');
				break;
			}
			else if (firstArr[i] < secondArr[i]) {
				console.log('First array is earlier.');
				break;
			}
			else {
				console.log('Arrays are equal.');
			}
		}
	}
	else {
		console.log('First array is earlier.');
	}
	
	function randomString(length) {
		var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
		var randomStr = '';
		for (var i = 0; i < length; i++) {
			var rndNum = Math.floor(Math.random() * chars.length);
			randomStr += chars.substring(rndNum, rndNum + 1);
		}

		return randomStr;
	}
}

solveTask(5, 6);
solveTask(60, 60);
solveTask(45, 44);