function solve() {
	var player = (function() {
		var player = {
			get name() {
				return this._name;
			},
			set name(value) {
				this._name = value;
			},
			init: function(name) {
				this.name = name;
				this.playlists = [];

				return this;
			},
			getPlayer: function(name) {
				return Object.create(player).init(name);
			},
			addPlaylist: function(name) {
				var newPlaylist = Object.create(playlist).init(name);
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

				return this;
			},
			listPlaylists: function(page, size) {
				// TODO: Implement method
			}
		};
		return player;
	}());

	var playlist = (function() {
		var playlist = {
			get id() {
				return this._id;
			},
			set id(value) {
				this._id = value;
			},
			get name() {
				return this._name;
			},
			set name(value) {
				this._name = value;
			},
			init: function(id, name) {
				this.id = id;
				this.name = name;
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
				var index;

				this.audios.forEach(function(audio, position) {
					if (audio.id == id) {
						index = position;
					}
				});

				if (index > -1) {
					this.audios.splice(index, 1);
				}

				return this;
			}
		};

		return playlist;
	}());

	var playable = (function() {
		var playable = {
			get id() {
				return this._id;
			},
			set id(value) {
				this._id = value;
			},
			get title() {
				return this._title;
			},
			set title(value) {
				this._title = value;
			},
			get author() {
				return this._author;
			},
			set author(value) {
				this._author = value;
			},
			init: function(id, title, author) {
				this.id = id;
				this.title = title;
				this.author = author;

				return this;
			},
			play: function() {
				var result = '' + this.id + '. ' + this.title + ' - ' + this.author;

				return result;
			}
		};

		return playable;
	}());

	var audio = (function(parent) {
		var audio = Object.create(parent, {
			length: {
				get: function() {
					return this._length;
				},
				set: function(value) {
					this._length = value;
				},
				enumerable: true,
				configurable: true
			},
			init: {
				value: function(id, title, author, length) {
					parent.init.call(this, id, title, author);
					this.length = length;

					return this;
				},
				enumerable: true,
				configurable: true,
				writable: true
			},
			play: {
				value: function() {
					var baseResult = parent.play.call(this);
					baseResult += ' - ' + this.length;

					return baseResult;
				},
				enumerable: true,
				configurable: true,
				writable: true
			}
		});

		return audio;
	}(playable));

	var video = (function(parent) {
		var video = Object.create(parent, {
			imdbRating: {
				get: function() {
					return this._imdbRating;
				},
				set: function(value) {
					this._imdbRating = value;
				},
				enumerable: true,
				configurable: true
			},
			init: {
				value: function(id, title, author, imdbRating) {
					parent.init.call(this, id, title, author);
					this.imdbRating = imdbRating;

					return this;
				},
				enumerable: true,
				configurable: true,
				writable: true
			},
			play: {
				value: function() {
					var baseResult = parent.play.call(this);
					baseResult += ' - ' + this.imdbRating;

					return baseResult;
				},
				enumerable: true,
				configurable: true,
				writable: true
			}
		});

		return video;
	}(playable));
}

module.exports = solve;