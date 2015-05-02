function solveTask() {
	var input = '((a+b)/5-d)';

	function isValidExpression(expression) {
		var bracketCount = 0;

		for (var i = 0; i < expression.length; i++) {
			if (expression[i] == '(') {
				bracketCount++;
			}
			else if (expression[i] == ')') {
				bracketCount--;
			}

			if (bracketCount < 0) {
				return false;
			}
		}

		return bracketCount === 0;
	}

	var isValid = isValidExpression(input);
	console.log(isValid);
}

solveTask();