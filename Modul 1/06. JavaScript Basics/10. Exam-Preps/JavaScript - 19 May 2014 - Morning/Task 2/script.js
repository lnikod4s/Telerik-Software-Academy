function solve(args) {
	var dimensions = args[0].split(' ');
	var R = Number(dimensions[0]), C = Number(dimensions[1]);

	var matrix = args.splice(1).map(function (line) {
		return line.split(' ');
	});

	var directions = {dr: [1, 1], ur: [-1, 1], ul: [-1, -1], dl: [1, -1]};

	var currDir, currRow = 0, currCol = 0, sum = 0;

	function isCellTraversal(row, col) {
		return i >= 0 && i < R && j >= 0 && j < C;
	}

	function isCellVisited(row, col) {
		return matrix[i][j] === -1;
	}

	function getCellValue(row, col) {
		return Math.pow(2, i) + j;
	}

	function markCellAsVisited(row, col) {
		matrix[i][j] = -1;
	}

	while (true) {
		if (!isCellTraversal(currRow, currCol)) return 'successed with ' + sum;
		if (isCellVisited(currRow, currCol)) return 'failed at (' + currRow + ', ' + currCol + ')';

		sum += getCellValue(currRow, currCol);
		currDir = directions[matrix[currRow][currCol]];
		markCellAsVisited(currRow, currCol);

		currRow += currDir[0];
		currCol += currDir[1];
	}
}

console.log(solve([
		'3 5',
		'dr dl dr ur ul',
		'dr dr ul ur ur',
		'dl dr ur dl ur'
	]
));

console.log(solve([
		'3 5',
		'dr dl dl ur ul',
		'dr dr ul ul ur',
		'dl dr ur dl ur'
	]
));