function solve(args) {
	var dimensions = args.shift().split(' ').map(function (a) {
		return parseInt(a);
	});

	var R = dimensions[0];
	var C = dimensions[1];

	var matrix = args.map(function (currLine) {
		return currLine.split(' ');
	});

	var directions = {dr: [1, 1], ur: [-1, 1], ul: [-1, -1], dl: [1, -1]};
	
	function getValue(row, col) {
		return Math.pow(2, row) + col;
	}

	function isCellTraversal(row, col) {
		return row >= 0 && row < R && col >= 0 && col < C;
	}
	
	function markCellAsVisited(row, col) {
		matrix[row][col] = 'X';
	}

	function isCellVisited(row, col) {
		return matrix[row][col] === 'X';
	}

	var currDir, currRow = 0, currCol = 0, sum = 0;
	while (true) {
		if (!isCellTraversal(currRow, currCol)) {
			return "successed with " + sum;
		}

		if (isCellVisited(currRow, currCol)) {
			return "failed at (" + currRow + ", " + currCol + ")";
		}

		sum += getValue(currRow, currCol);
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