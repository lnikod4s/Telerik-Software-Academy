function solve(args) {
	var initialData = args[0].split(' '),
		N = Number(initialData[0]),
		M = Number(initialData[1]),
		J = Number(initialData[2]),
		startPos = args[1].split(' '),
		currRow = Number(startPos[0]),
		currCol = Number(startPos[1]),
		matrix = [],
		i,
		j,
		sum = 0,
		jump = 0,
		currJump,
		jumps = args.slice(2).map(function (line) {
			return line.split(' ').map(Number)
		}),
		jumpsCount = 0;

	for (i = 0; i < N; i++) {
		matrix[i] = [];
		for (j = 0; j < M; j++) {
			matrix[i][j] = M * i + j + 1;
		}
	}

	function isCellTraversal(row, col) {
		return row >= 0 && row < N && col >= 0 && col < M;
	}

	function isCellVisited(row, col) {
		return matrix[row][col] == 'x';
	}

	function getCellValue(row, col) {
		return matrix[row][col];
	}

	function markCellAsVisited(row, col) {
		matrix[row][col] = 'x';
	}

	while (true) {
		if (!isCellTraversal(currRow, currCol)) {
			return 'escaped ' + sum;
		}
		if (isCellVisited(currRow, currCol)) {
			return 'caught ' + jumpsCount;
		}

		sum += getCellValue(currRow, currCol);
		jump %= jumps.length;
		currJump = jumps[jump];
		markCellAsVisited(currRow, currCol);

		currRow += currJump[0];
		currCol += currJump[1];
		jumpsCount++;
		jump++;
	}
}

console.log(solve([
	'6 7 3',
	'0 0',
	'2 2',
	'-2 2',
	'3 -1'
]));