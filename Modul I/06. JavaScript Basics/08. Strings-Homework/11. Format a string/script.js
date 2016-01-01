function solveTask() {
	function stringFormat(str) {
		var selfArguments = arguments;

		return str.replace(/\{(\d+)}/g, function (match, arg) {
			return selfArguments[+arg + 1];
		});
	}

	var str1 = stringFormat("Hello {0}!", "Peter");

	console.log(str1);

	var format = "{0}, {1}, {0} text {2}";
	var str2 = stringFormat(format, 1, "Pesho", "Gosho");

	console.log(str2);
}

solveTask();