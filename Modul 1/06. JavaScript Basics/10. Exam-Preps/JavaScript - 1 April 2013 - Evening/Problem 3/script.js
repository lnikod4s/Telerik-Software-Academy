function solve(args) {
	var arr = args.map(function (item, index) {
		return item.trim().substr(0, 3) === 'def' ? item.slice(3).trim() : item.trim();
	});

	var output;
	var functions = {};

	function processParams(str) {
		var values;
		if (str[0] === '[') {
			str = str.slice(1, -1).trim();
			values = str.split(',')
				.filter(function (item) { return item; })
				.map(function (item) {
					item = item.trim();
					if (isNumber(item)) {
						item = Number(item);
					} else {
						item = Number(functions[item]);
					}

					return item;
				});
			return values;
		} else {
			var operation = str.substr(0, 3);
			str = str.slice(3).trim();
			str = str.slice(1, -1).trim();
			if (functions.hasOwnProperty(str)) {
				values = Array.isArray(functions[str]) ? functions[str].slice() : functions[str];
			} else {
				values = str.split(',')
					.filter(function (item) { return item; })
					.map(function (item) {
						if (isNumber(item)) {
							item = Number(item);
						} else {
							item = item.trim();
							if (isNumber(functions[item])) {
								item = Number(functions[item]);
							} else {
								item = [].concat(functions[item]);
							}
						}

						return item;
					});
			}

			if (containsArray(values)) {
				var flattened = values.reduce(flat, []);
				values = flattened.slice();
			}

			var answer;
			switch (operation) {
				case 'sum':
					if (!Array.isArray(values)) {
						answer = values;
						break;
					}
					answer = values.reduce(function (x, y) {
						return x + y;
					});
					break;
				case 'min':
					if (!Array.isArray(values)) {
						answer = values;
						break;
					}
					answer = values.reduce(function (previous, current) {
						return previous < current ? previous : current
					});
					break;
				case 'max':
					if (!Array.isArray(values)) {
						answer = values;
						break;
					}
					answer = values.reduce(function (previous, current) {
						return previous > current ? previous : current
					});
					break;
				case 'avg':
					if (!Array.isArray(values)) {
						answer = values;
						break;
					}
					answer = Math.floor(values.reduce(function (x, y) {
							return x + y;
						}) / values.length);
					break;
			}

			return answer;
		}
	}

	function isNumber(n) {
		return !isNaN(parseFloat(n)) && isFinite(n);
	}

	function containsArray(arr) {
		var hasNestedArray = false;
		for (var i = 0; i < arr.length; i += 1) {
			if (Array.isArray(arr[i])) {
				hasNestedArray = true;
			}
		}

		return hasNestedArray;
	}

	function flat(a, b) { return a.concat(b); }

	for (var row = 0; row < arr.length; row += 1) {
		var line = arr[row];
		if (row === arr.length - 1) {
			output = processParams(line);
			break;
		}
		var nextWhiteSpaceIndex = line.indexOf(' ');
		var nextSquareBracketIndex = line.indexOf('[');
		var currVar, params;
		if (nextWhiteSpaceIndex !== -1 && nextWhiteSpaceIndex < nextSquareBracketIndex) {
			currVar = line.substring(0, nextWhiteSpaceIndex);
			params = line.substr(nextWhiteSpaceIndex).trim();
		} else {
			currVar = line.substring(0, nextSquareBracketIndex);
			params = line.substr(nextSquareBracketIndex).trim();
		}
		var varValue = processParams(params);
		functions[currVar] = varValue;
	}

	if (Array.isArray(output)) {
		output = output[0];
	}

	return output;
}

console.log(solve([
	'def maxy max[100]',
	'def summary [0]',
	'combo [maxy, maxy,maxy,maxy, 5,6]',
	'summary sum[combo, maxy, -18000]',
	'def pe6o avg[summary,maxy]',
	'sum[7, pe6o]'
]));