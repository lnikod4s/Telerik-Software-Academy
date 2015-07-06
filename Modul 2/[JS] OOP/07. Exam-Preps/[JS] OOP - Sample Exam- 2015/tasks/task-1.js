function solve() {
	var Player = (function() {
		var Player = {
			init: function(name) {
				this.name = name;
				this.playlists = [];

				return this;
			},
			getPlayer: function(name) {
				return Object.create(Player).init(name);
			},
			addPlaylist: function(name) {
				var newPlaylist = Object.create(Playlist).init(name);
				this.playlists.push(newPlaylist);
			},
			getPlaylistById: function(id) {
				var result = null;

				this.playlists.forEach(function(playlist) {
					if (playlist.id == id) {
						result = playlist;
					}
				});

				return result;
			},
			removePlaylistById: function(id) {
				var index;

				this.playlists.forEach(function(playlist, position) {
					if (playlist.id == id) {
						index = position;
					}
				});

				if (index > -1) {
					this.playlists.splice(index, 1);
				}
			},
			listPlaylists: function(page, size) {
				// TODO: Implement method
			}
		};
		return Player;
	}());

	var Playlist = (function() {
		var Playlist = {
			init: function(id, name) {
				this._id = id;
				this._name = name;
				this.audios = [];
				this.videos = [];

				return this;
			},
			addAudio: function(audio) {
				var id = 0;

				if (this.audios.indexOf(audio) == -1) {
					audio.id = ++id;
				}

				this.audios.push(audio);

				return this;
			},
			getAudioById: function(id) {
				var result = null;

				this.audios.forEach(function(audio) {
					if (audio.id == id) {
						result = audio;
					}
				});

				return result;
			},
			removeAudioById: function(id) {
				this.audios.forEach(function(audio) {
					if (audio.id == id) {
						delete audio;
						return;
					}
				});

				return this;
			}
		};

		return Playlist;
	}());

	var Playable = (function() {
		var Playable = {};
		
		Object.defineProperty(Playable, 'init', {
			configurable: true,
			enumerable: true,
			value: function(id, title, author) {
				// TODO: Abstract class validation
				this.id = id;
				this.title = title;
				this.author = author;

				return this;
			},
			writable: true
		});

		Object.defineProperty(Playable, 'play', {
			configurable: true,
			enumerable: true,
			value: function() {
				var result = '' + this.id + '. ' + this.title + ' - ' + this.author;

				return result;
			},
			writable: true
		});

		Object.defineProperty(Playable, 'id', {
			get: function() {
				return this.id;
			},
			set: function(value) {
				// TODO: Validation
				this.id = value;
			},
			enumerable: true,
			configurable: true
		});

		Object.defineProperty(Playable, 'title', {
			get: function() {
				return this.title;
			},
			set: function(value) {
				// TODO: Validation
				this.title = value;
			},
			enumerable: true,
			configurable: true
		});

		Object.defineProperty(Playable, 'author', {
			get: function() {
				return this.author;
			},
			set: function(value) {
				// TODO: Validation
				this.author = value;
			},
			enumerable: true,
			configurable: true
		});
		
		return Playable;
	}());

	var Audio = (function(parent) {
		var Audio = Object.create(parent);

		Object.defineProperty(Audio, 'init', {
			configurable: true,
			enumerable: true,
			value: function(id, title, author, length) {
				parent.init.call(this, id, title, author);
				this.length = length;

				return this;
			},
			writable: true
		});

		Object.defineProperty(Audio, 'play', {
			configurable: true,
			enumerable: true,
			value: function() {
				var baseResult = parent.play.call(this);
				baseResult += ' - ' + this.length;

				return baseResult;
			},
			writable: true
		});

		Object.defineProperty(Audio, 'length', {
			get: function() {
				return this.length;
			},
			set: function(value) {
				// TODO: Validation
				this.length = value;
			},
			enumerable: true,
			configurable: true
		});

		return Audio;
	}(Playable));

	var Video = (function(parent) {
		var Video = Object.create(parent);

		Object.defineProperty(Video, 'init', {
			configurable: true,
			enumerable: true,
			value: function(id, title, author, imdbRating) {
				parent.init.call(this, id, title, author);
				this.imdbRating = imdbRating;

				return this;
			},
			writable: true
		});

		Object.defineProperty(Video, 'play', {
			configurable: true,
			enumerable: true,
			value: function() {
				var baseResult = parent.play.call(this);
				baseResult += ' - ' + this.imdbRating;

				return baseResult;
			},
			writable: true
		});

		Object.defineProperty(Video, 'imdbRating', {
			get: function() {
				return this.imdbRating;
			},
			set: function(value) {
				// TODO: Validation
				this.imdbRating = value;
			},
			enumerable: true,
			configurable: true
		});

		return Video;
	}(Playable));
}

module.exports = solve;