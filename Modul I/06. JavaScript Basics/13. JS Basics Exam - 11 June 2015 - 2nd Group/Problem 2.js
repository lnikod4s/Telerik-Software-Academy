function solve(params) {
	var rows = parseInt(params[0]),
		cols = parseInt(params[1]),
		tests = parseInt(params[rows + 2]), i, move;

	function fillChessBoard() {
		var matrix = [];
		var str = '';
		for (var row = 0; row < rows; row += 1) {
			matrix[row] = [];
			var index = '' + (rows - row);
			for (var col = 0; col < cols; col += 1) {
				var char = String.fromCharCode(97 + col);
				matrix[row][col] = char + index;
			}
		}

		return matrix;
	}

	function fillFiguresMatrix() {
		var matrix = [];

		for (var row = 0; row < rows; row += 1) {
			matrix[row] = params[row + 2].split('');
		}

		return matrix;
	}

	var chessMatrix = fillChessBoard();
	var chessFiguresMatrix = fillFiguresMatrix();
	for (i = 0; i < tests; i++) {
		move = params[rows + 3 + i];
		var figure = move[0];
		
	}
}

console.log(solve([
	'3',
	'4',
	'--R-',
	'B--B',
	'Q--Q',
	'12',
	'd1 b3',
	'a1 a3',
	'c3 b2',
	'a1 c1',
	'a1 b2',
	'a1 c3',
	'a2 b3',
	'd2 c1',
	'b1 b2',
	'c3 b1',
	'a2 a3',
	'd1 d3'
]));

//console.log(solve([
//	'5',
//	'5',
//	'Q---Q',
//	'-----',
//	'-B---',
//	'--R--',
//	'Q---Q',
//	'10',
//	'a1 a1',
//	'a1 d4',
//	'e1 b4',
//	'a5 d2',
//	'e5 b2',
//	'b3 d5',
//	'b3 a2',
//	'b3 d1',
//	'b3 a4',
//	'c2 c5'
//]));