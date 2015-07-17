var canvas = document.getElementById('circle-canvas'),
	ctx = canvas.getContext('2d'),
	x = 350,
	y = 100,
	r = 20,
	x_dir = 1,
	y_dir = 1;

ctx.strokeStyle = "black";
ctx.fillStyle = "red";
ctx.lineWidth = 5;

(function flyingMadness() {
	ctx.clearRect(0, 0, canvas.width, canvas.height);

	// Drawing flying circle
	ctx.beginPath();
	ctx.arc(x, y, r, 0, 2 * Math.PI);
	ctx.fill();
	ctx.stroke();

	// Bouncing criteria
	if ((x + r) >= canvas.width || (x <= r)) {
		x_dir *= -1;
	}

	if ((y + r) >= canvas.height || (y <= r)) {
		y_dir *= -1;
	}

	// Adding velocity
	x += 40 * x_dir;
	y += 40 * y_dir;

	requestAnimationFrame(flyingMadness);
}());