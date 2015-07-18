$(document).ready(function() {
	var canvas = $("#canvas")[0],
		ctx = canvas.getContext("2d"),
		w = $("#canvas").width(),
		h = $("#canvas").height(),
		cw = 10,
		d,
		food,
		score,
		snake_array;
	
	function init() {
		d = "right"; // default direction
		create_snake();
		create_food();
		score = 0;

		if (typeof game_loop != "undefined") {
			clearInterval(game_loop);
		}

		// Adjusting game speed
		game_loop = setInterval(paint, 60);
	}

	init();
	
	function create_snake() {
		var length = 5;
		snake_array = [];
		for (var i = length - 1; i >= 0; i--) {
			//This will create a horizontal snake starting from the top left
			snake_array.push({x: i, y: 0});
		}
	}
	
	// This will create a cell with x/y between 0-44
	// Because there are 45(450/10) positions across the rows and columns
	function create_food() {
		food = {
			x: Math.round(Math.random() * (w - cw) / cw),
			y: Math.round(Math.random() * (h - cw) / cw)
		};
	}

	function paint() {
		ctx.fillStyle = "white";
		ctx.fillRect(0, 0, w, h);
		ctx.strokeStyle = "black";
		ctx.strokeRect(0, 0, w, h);

		// Pop out the tail cell and place it in front of the head cell
		var nx = snake_array[0].x;
		var ny = snake_array[0].y;
		if (d == "right") {
			nx++;
		} else if (d == "left") {
			nx--;
		} else if (d == "up") {
			ny--;
		} else if (d == "down") {
			ny++;
		}

		// If the head of the snake bumps into its body, the game will restart
		if (nx == -1 || nx == w / cw || ny == -1 || ny == h / cw || check_collision(nx, ny, snake_array)) {
			init();
			return;
		}

		// If the new head position matches with that of the food,
		// create a new head instead of moving the tail
		var tail;
		if (nx == food.x && ny == food.y) {
			tail = {x: nx, y: ny};
			score++;
			create_food();
		}
		else {
			tail = snake_array.pop(); // pops out the last cell
			tail.x = nx;
			tail.y = ny;
		}
		
		snake_array.unshift(tail); // puts back the tail as the first cell
		
		for (var i = 0; i < snake_array.length; i++) {
			var c = snake_array[i];
			paint_cell(c.x, c.y);
		}

		paint_cell(food.x, food.y);
		var score_text = "Score: " + score;
		ctx.fillText(score_text, 5, h - 5);
	}

	function paint_cell(x, y) {
		ctx.fillStyle = "green";
		ctx.fillRect(x * cw, y * cw, cw, cw);
		ctx.strokeStyle = "white";
		ctx.strokeRect(x * cw, y * cw, cw, cw);
	}
	
	function check_collision(x, y, array) {
		for (var i = 0; i < array.length; i++) {
			if (array[i].x == x && array[i].y == y) {
				return true;
			}
		}

		return false;
	}

	// Adding key controls
	$(document).keydown(function(e) {
		var key = e.which;
		if (key == "37" && d != "right") {
			d = "left";
		} else if (key == "38" && d != "down") {
			d = "up";
		} else if (key == "39" && d != "left") {
			d = "right";
		} else if (key == "40" && d != "up") {
			d = "down";
		}
	})
});