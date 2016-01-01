function solve() {
	var Player,
		Playlist,
		Playable,
		Audio,
		Video;

	// ---------------------------------------- Helper Functions ----------------------------------------
	if (!Array.prototype.findIndex) {
		Array.prototype.findIndex = function(predicate) {
			if (this == null) {
				throw new TypeError('Array.prototype.findIndex called on null or undefined');
			}

			if (typeof predicate !== 'function') {
				throw new TypeError('predicate must be a function');
			}

			var list = Object(this);
			var length = list.length >>> 0;
			var thisArg = arguments[1];
			var value;

			for (var i = 0; i < length; i++) {
				value = list[i];
				if (predicate.call(thisArg, value, i, list)) {
					return i;
				}
			}

			return -1;
		};
	}

	function isInteger(x) {
		return ((x ^ 0) === x);
	}
	// **************************************************************************************************

	Player = (function() {
		var playerId = 0;

		function Player(name) {
			this.setId(++playerId);
			this.setName(name);
			this.playlists = [];
		}

		Player.prototype.getId = function() {
			return this.id;
		};

		Player.prototype.setId = function(value) {
			// TODO: Validation
			this.id = value;
		};

		Player.prototype.getName = function() {
			return this.name;
		};

		Player.prototype.setName = function(value) {
			// TODO: Validation
			this.name = value;
		};

		Player.prototype.getPlayer = function(name) {
			return new Player(name);
		};

		Player.prototype.addPlaylist = function(playlistToAdd) {
			if (!playlistToAdd instanceof Playlist) {
				throw new Error('playlistToAdd must be a PlayList instance.');
			}

			this.playlists.push(playlistToAdd);
			
			return this;
		};

		Player.prototype.getPlaylistById = function(id) {
			var i,
				len;

			for (i = 0, len = this.playlists.length; i < len; i++) {
				if (this.playlists[i].id === id) {
					return this.playlists[i];
				}
			}

			return null;
		};

		Player.prototype.removePlaylist = function(id) {
			var index;
			index = this.playlists.findIndex(function(playlist) {
				return playlist.id === id;
			});

			if (index < 0) {
				throw {
					name: 'InvalidIdError',
					message: 'InvalidIdError'
				};
			}
			this.playlists.splice(index, 1);

			return this;
		};

		return Player;
	}());

	Playlist = (function() {
		var playlistId = 0;

		function Playlist(name) {
			this.setId(++playlistId);
			this.setName(name);
			this.playables = [];
		}

		Playlist.prototype.getId = function() {
			return this.id;
		};

		Playlist.prototype.setId = function(value) {
			// TODO: Validation
			this.id = value;
		};

		Playlist.prototype.getName = function() {
			return this.name;
		};

		Playlist.prototype.setName = function(value) {
			// TODO: Validation
			this.name = value;
		};

		Playlist.prototype.addPlayable = function(playable) {
			this.playables.push(playable);
			return this;
		};

		Playlist.prototype.getPlayableById = function(id) {
			var i,
				len;

			for (i = 0, len = this.playables.length; i < len; i++) {
				if (this.playables[i].id === id) {
					return this.playables[i];
				}
			}

			return null;
		};

		Playlist.prototype.removePlayable = function(argument) {
			var index;
			if (isInteger(argument)) {
				index = this.playables.findIndex(function(playable) {
					return playable.id === argument;
				});
			} else {
				index = this.playables.indexOf(argument);
			}

			if (index < 0) {
				throw {
					name: 'InvalidIdError',
					message: 'InvalidIdError'
				};
			}
			this.playables.splice(index, 1);

			return this;
		};

		Playlist.prototype.listPlayables = function(page, size) {
			var sortedPlayables,
				startIndex = page * size,
				endIndex = (page + 1) * size;

			if (page * size > this.playables.length) {
				throw new Error('Out of range arguments.');
			}

			if (page < 0) {
				throw new Error('Page cannot be less than zero.');
			}

			if (size <= 0) {
				throw new Error('Size cannot be less than or equal zero.');
			}

			sortedPlayables = this.playables.slice(0);
			sortedPlayables = sortedPlayables.sort(function(previous, next) {
				if (previous.title === next.title) {
					return previous.id - next.id;
				}
				return previous.getTitle().localeCompare(next.getTitle());
			});

			return sortedPlayables.slice(startIndex, endIndex);
		};

		return Playlist;
	}());

	Playable = (function() {
		var playableId = 0;

		function Playable(title, author) {
			if (this.constructor === Playable) {
				throw new Error('Can\'t instantiate abstract class!');
			}

			this.setId(++playableId);
			this.setTitle(title);
			this.setAuthor(author);
		}

		Playable.prototype.getId = function() {
			return this.id;
		};

		Playable.prototype.setId = function(value) {
			// TODO: Validation
			this.id = value;
		};

		Playable.prototype.getTitle = function() {
			return this.title;
		};

		Playable.prototype.setTitle = function(value) {
			// TODO: Validation
			this.title = value;
		};

		Playable.prototype.getAuthor = function() {
			return this.author;
		};

		Playable.prototype.setAuthor = function(value) {
			// TODO: Validation
			this.author = value;
		};

		Playable.prototype.play = function() {
			return this.getId() + '. ' +
				this.getTitle() + ' - ' +
				this.getAuthor();
		};

		return Playable;
	}());

	Audio = (function(parent) {
		function Audio(title, author, length) {
			parent.call(this, title, author);
			this.setLength(length);
		}

		Audio.prototype.getLength = function() {
			return this.length;
		};

		Audio.prototype.setLength = function(value) {
			// TODO: Validation
			this.length = value;
		};

		Audio.prototype.play = function() {
			var superPlay = parent.prototype.play.call(this);
			return superPlay + ' - ' + this.getLength();
		};

		return Audio;
	}(Playable));

	Video = (function(parent) {
		function Video(title, author, imdbRating) {
			parent.call(this, title, author);
			this.setImdbRating(imdbRating);
		}

		Video.prototype.getImdbRating = function() {
			return this.imdbRating;
		};

		Video.prototype.setImdbRating = function(value) {
			// TODO: Validation
			this.imdbRating = value;
		};

		Video.prototype.play = function() {
			var superPlay = parent.prototype.play.call(this);
			return superPlay + ' - ' + this.getImdbRating();
		};

		return Video;
	}(Playable));

	function getPlayer(name) {
		return new Player(name);
	}

	function getPlaylist(name) {
		return new Playlist(name);
	}

	function getAudio(title, author, length) {
		return new Audio(title, author, length);
	}

	function getVideo(title, author, imdbRating) {
		return new Video(title, author, imdbRating);
	}

	return {
		getPlayer: getPlayer,
		getPlaylist: getPlaylist,
		getAudio: getAudio,
		getVideo: getVideo
	};
}

module.exports = solve;