function solve(args) {
	var dimensions = args[0].split(' '),
		N = Number(dimensions[0]),
		M = Number(dimensions[1]),
		initialPos = args[1].split(' '),
		R = Number(initialPos[0]),
		C = Number(initialPos[1]),
		directions = {l: [0, -1], r: [0, 1], u: [-1, 0], d: [1, 0]},
		matrix = args.slice(2).map(function (line) {
			return line.split('')
		}),
		currRow = R,
		currCol = C,
		sum = 0,
		jumps = 0,
		currDir;
	
	function isCellTraversal(row, col) {
		return i >= 0 && i < N && j >= 0 && j < M;
	}

	function isCellVisited(row, col) {
		return matrix[i][j] === 'x';
	}

	function getCellValue(row, col) {
		return i === 0 ? j + 1 : (M * i) + j + 1;
	}

	function markCellAsVisited(row, col) {
		matrix[i][j] = 'x';
	}

	while (true) {
		if (!isCellTraversal(currRow, currCol)) return 'out ' + sum;
		if (isCellVisited(currRow, currCol)) return 'lost ' + jumps;

		sum += getCellValue(currRow, currCol);
		currDir = directions[matrix[currRow][currCol]];
		markCellAsVisited(currRow, currCol);

		currRow += currDir[0];
		currCol += currDir[1];
		jumps++;
	}
}

console.log(solve([
	"3 4",
	"1 3",
	"lrrd",
	"dlll",
	"rddd"
]));

console.log(solve([
	"5 8",
	"0 0",
	"rrrrrrrd",
	"rludulrd",
	"durlddud",
	"urrrldud",
	"ulllllll"
]));

console.log(solve([
	"5 8",
	"0 0",
	"rrrrrrrd",
	"rludulrd",
	"lurlddud",
	"urrrldud",
	"ulllllll"
]));