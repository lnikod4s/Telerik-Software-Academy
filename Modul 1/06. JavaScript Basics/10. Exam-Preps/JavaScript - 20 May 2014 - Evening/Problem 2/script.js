function solve(args) {
	var dimensions = args[0].split(' '),
		R = Number(dimensions[0]),
		C = Number(dimensions[1]),
		currRow = R - 1,
		currCol = C - 1,
		sum = 0,
		jumps = 0,
		currDir;

	var matrix = args.splice(1).map(function (line) {
		return line.split('');
	});

	var directions = {
		1: [-2, 1],
		2: [-1, 2],
		3: [1, 2],
		4: [2, 1],
		5: [2, -1],
		6: [1, -2],
		7: [-1, -2],
		8: [-2, -1]
	};

	function isCellTraversal(row, col) {
		return i >= 0 && i < R && j >= 0 && j < C;
	}

	function isCellVisited(row, col) {
		return matrix[i][j] === 'x';
	}

	function getCellValue(row, col) {
		return Math.pow(2, i) - j;
	}

	function markCellAsVisited(row, col) {
		matrix[i][j] = 'x';
	}

	while (true) {
		if (!isCellTraversal(currRow, currCol)) return 'Go go Horsy! Collected ' + sum + ' weeds';
		if (isCellVisited(currRow, currCol)) return 'Sadly the horse is doomed in ' + jumps + ' jumps';

		sum += getCellValue(currRow, currCol);
		currDir = directions[matrix[currRow][currCol]];
		markCellAsVisited(currRow, currCol);

		currRow += currDir[0];
		currCol += currDir[1];
		jumps++;
	}
}

console.log(
	solve([
		'3 5',
		'54561',
		'43328',
		'52388'
	])
);

console.log(
	solve([
		'3 5',
		'54361',
		'43326',
		'52188'
	])
);