var sprites = {
	ship: {sx: 0, sy: 0, w: 18, h: 35, frames: 3}
};

var startGame = function() {
	Game.setBoard(0, new Starfield(20, 0.4, 100, true));
	Game.setBoard(1, new Starfield(50, 0.6, 100));
	Game.setBoard(2, new Starfield(100, 1.0, 50));
	Game.setBoard(3, new TitleScreen("Alien Invasion",
	                                 "Press fire to start playing",
	                                 playGame));
};

var playGame = function() {
	Game.setBoard(3, new PlayerShip());
};

window.addEventListener("load", function() {
	Game.initialize("game", sprites, startGame);
});

var Starfield = function(speed, opacity, numStars, clear) {

	// Set up the offscreen canvas
	var stars = document.createElement("canvas");
	stars.width = Game.width;
	stars.height = Game.height;
	var starCtx = stars.getContext("2d");

	var offset = 0;

	// If the clear option is set,
	// make the background black instead of transparent
	if (clear) {
		starCtx.fillStyle = "#000";
		starCtx.fillRect(0, 0, stars.width, stars.height);
	}

	// Now draw a bunch of random 2 pixel
	// rectangles onto the offscreen canvas
	starCtx.fillStyle = "#FFF";
	starCtx.globalAlpha = opacity;
	for (var i = 0; i < numStars; i++) {
		starCtx.fillRect(Math.floor(Math.random() * stars.width),
		                 Math.floor(Math.random() * stars.height),
		                 2,
		                 2);
	}

	// This method is called every frame
	// to draw the starfield onto the canvas
	this.draw = function(ctx) {
		var intOffset = Math.floor(offset);
		var remaining = stars.height - intOffset;

		// Draw the top half of the starfield
		if (intOffset > 0) {
			ctx.drawImage(stars,
			              0, remaining,
			              stars.width, intOffset,
			              0, 0,
			              stars.width, intOffset);
		}

		// Draw the bottom half of the starfield
		if (remaining > 0) {
			ctx.drawImage(stars,
			              0, 0,
			              stars.width, remaining,
			              0, intOffset,
			              stars.width, remaining);
		}
	};

	// This method is called to update
	// the starfield
	this.step = function(dt) {
		offset += dt * speed;
		offset = offset % stars.height;
	}
};

var PlayerShip = function() {
	this.w = SpriteSheet.map['ship'].w;
	this.h = SpriteSheet.map['ship'].h;
	this.x = Game.width / 2 - this.w / 2;
	this.y = Game.height - 10 - this.h;
	this.vx = 0;
	this.step = function(dt) {
		if (Game.keys['left']) {
			this.vx = -this.maxVel;
		} else if (Game.keys['right']) {
			this.vx = this.maxVel;
		} else {
			this.vx = 0;
		}

		this.x += this.vx * dt;
		if (this.x < 0) {
			this.x = 0;
		}
		else if (this.x > Game.width - this.w) {
			this.x = Game.width - this.w;
		}
		this.draw = function(ctx) {
			SpriteSheet.draw(ctx, 'ship', this.x, this.y, 1);
		}
	};
};