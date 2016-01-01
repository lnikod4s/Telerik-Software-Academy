////////////////////////////////////////////////////////////
//          requestAnimationFrame Polyfill                //
////////////////////////////////////////////////////////////

(function() {
	var lastTime = 0;
	var vendors = ['ms', 'moz', 'webkit', 'o'];
	for (var x = 0; x < vendors.length && !window.requestAnimationFrame; ++x) {
		window.requestAnimationFrame = window[vendors[x] + 'RequestAnimationFrame'];
		window.cancelAnimationFrame =
			window[vendors[x] + 'CancelAnimationFrame'] ||
			window[vendors[x] + 'CancelRequestAnimationFrame'];
	}

	if (!window.requestAnimationFrame) {
		window.requestAnimationFrame = function(callback, element) {
			var currTime = new Date().getTime();
			var timeToCall = Math.max(0, 16 - (currTime - lastTime));
			var id = window.setTimeout(function() {
				                           callback(currTime + timeToCall);
			                           },
			                           timeToCall);
			lastTime = currTime + timeToCall;
			return id;
		};
	}

	if (!window.cancelAnimationFrame) {
		window.cancelAnimationFrame = function(id) {
			clearTimeout(id);
		};
	}
}());

$(window).load(function() {
	game.init();
});

////////////////////////////////////////////////////////////
//                      Game Engine                       //
////////////////////////////////////////////////////////////

var game = {
	// Start initializing objects, preloading assets and display start screen
	init: function() {
		levels.init();
		loader.init();

		// Hide all game layers and display the start screen
		$('.gamelayer').hide();
		$('#gamestartscreen').show();

		// Get handler for game canvas and context
		this.canvas = $('#gamecanvas')[0];
		this.context = this.canvas.getContext('2d');
	},
	showLevelScreen: function() {
		$('.gamelayer').hide();
		$('#levelselectscreen').show('slow');
	}
};

////////////////////////////////////////////////////////////
//                        Levels                          //
////////////////////////////////////////////////////////////

var levels = {
	// Level data
	data: [
		{ // First level
			foreground: 'foreground',
			background: 'background',
			entities: []
		},
		{ // Second level
			foreground: 'foreground',
			background: 'background',
			entities: []
		},
		{ // Third level
			foreground: 'foreground',
			background: 'background',
			entities: []
		}
	],
	// Initialize level selection screen
	init: function() {
		var html = "";
		for (var i = 0; i < levels.data.length; i++) {
			var level = levels.data[i];
			html += '<input type="button" value="' + (i + 1) + '">';
		}
		$('#levelselectscreen').html(html);

		// Set the button click event handlers to load level
		$('#levelselectscreen').find('input').click(function() {
			levels.load(this.value - 1);
			$('#levelselectscreen').hide();
		});
	},
	// Load all data and images for a specific level
	load: function(number) {
	}
};

////////////////////////////////////////////////////////////
//              Image/Sound Assets Loader                 //
////////////////////////////////////////////////////////////

var loader = {
	loaded: true,
	loadedCount: 0, // Assets that have been loaded so far
	totalCount: 0, // Total number of assets that need to be loaded
	init: function() {
		// Check for sound support
		var mp3Support, oggSupport;
		var audio = document.createElement('audio');
		if (audio.canPlayType) {
			// Currently canPlayType() returns: "", "maybe" or "probably"
			mp3Support = "" != audio.canPlayType('audio/mpeg');
			oggSupport = "" != audio.canPlayType('audio/ogg; codecs = "vorbis"');
		} else {
			// The audio tag is not supported
			mp3Support = false;
			oggSupport = false;
		}
		// Check for ogg, then mp3, and finally set soundFileExtn to undefined
		loader.soundFileExtn = oggSupport ? ".ogg" : mp3Support ? ".mp3" : undefined;
	},
	loadImage: function(url) {
		this.totalCount++;
		this.loaded = false;
		$('#loadingscreen').show();
		var image = new Image();
		image.src = url;
		image.onload = loader.itemLoaded;
		return image;
	},
	soundFileExtn: ".ogg",
	loadSound: function(url) {
		this.totalCount++;
		this.loaded = false;
		$('#loadingscreen').show();

		var audio = new Audio();
		audio.src = url + loader.soundFileExtn;
		audio.addEventListener("canplaythrough", loader.itemLoaded, false);
		return audio;
	},
	itemLoaded: function() {
		loader.loadedCount++;
		$('#loadingmessage').html('Loaded ' + loader.loadedCount + ' of ' + loader.totalCount);
		if (loader.loadedCount === loader.totalCount) {
			// Loader has loaded completely..
			loader.loaded = true;
			// Hide the loading screen
			$('#loadingscreen').hide();
			// and call the loader.onload method if it exists
			if (loader.onload) {
				loader.onload();
				loader.onload = undefined;
			}
		}
	}
};