function solve(args) {
	var arr = args.map(function (item) {
		item = item.trim().slice(1, -1);
		if (item.substr(0, 3) === 'def') {
			item = item.substr(3).trim();
		}

		return item.trim();
	});

	var output;
	var functions = {};

	for (var i = 0; i < arr.length; i += 1) {
		var line = arr[i];
		var nextWhiteSpaceIndex = line.indexOf(' ');
		var currVar = line.substring(0, nextWhiteSpaceIndex);
		var params = line.substr(nextWhiteSpaceIndex).trim();
		var varValue = processParams(params);
		if (varValue === 'Invalid division!') {
			output = 'Division by zero! At Line:' + (i + 1);
			break;
		}
		functions[currVar] = varValue;
		if (i === arr.length - 1) {
			output = processParams('(' + line + ')');
		}
	}
	
	function processParams(str) {
		if (isFinite(str)) {
			return Number(str);
		} else if (functions.hasOwnProperty(str)) {
			return Number(functions[str]);
		} else {
			str = str.slice(1, -1).trim();
			var operator = str[0];
			str = str.slice(1).trim();
			var values = str.split(' ')
				.filter(function (item) { return item})
				.map(function (item) {
					if (isFinite(item)) {
						item = Number(item);
					} else {
						item = Number(functions[item]);
					}

					return item;
				});

			var answer;
			switch (operator) {
				case '+':
					answer = values.reduce(function (x, y) {
						return x + y;
					});
					break;
				case '-':
					answer = values.reduce(function (x, y) {
						return x - y;
					});
					break;
				case '*':
					answer = values.reduce(function (x, y) {
						return x * y;
					});
					break;
				case '/':
					answer = values.reduce(function (x, y) {
						if (y === 0) {
							return 'Invalid division!'
						} else {
							return parseInt(x / y);
						}
					});
					break;
			}

			return answer;
		}
	}

	return output;
}

console.log(solve([
	'(def     go6o    (/ -7 1 1 1 1) )',
	'(def asd (/ 0 5))',
	'(def func2 asd  )',
	'(           +        4          2      func2)'
]));