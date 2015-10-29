function solve() {
	var Player,
		Playlist,
		Playable,
		Audio,
		Video;

	function deepCopy(p, c) {
		c = c || {};
		for (var i in p) {
			if (p.hasOwnProperty(i)) {
				if (typeof p[i] === 'object') {
					c[i] = Array.isArray(p[i]) ? [] : {};
					deepCopy(p[i], c[i]);
				} else {
					c[i] = p[i];
				}
			}
		}
		return c;
	}

	Player = (function() {
		function Player(name) {

		}

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
			return this.playables[id - 1] || null;
		};

		Playlist.prototype.removePlayable = function(id) {
			var index;
			index = this.playables[id - 1];

			if (index == -1) {
				throw new Error('Playable with the provided id is not contained in the playlist.');
			} else {
				this.playables.splice(index, 1);
			}

			return this;
		};

		//Playlist.prototype.removePlayable = function(playable) {
		//	var index;
		//	index = this.playables.indexOf(playable);
		//
		//	if (index == -1) {
		//		throw new Error('Playable with the provided id is not contained in the playlist.');
		//	} else {
		//		this.playables.splice(index, 1);
		//	}
		//
		//	return this;
		//};

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

			if (this.playables.length < size) {
				return this.playables.slice(0);
			}

			sortedPlayables = this.playables.slice(startIndex, endIndex);
			sortedPlayables = sortedPlayables.sort(function(previous, next) {
				return previous.getTitle().localeCompare(next.getTitle());
			});
			sortedPlayables = sortedPlayables.sort(function(previous, next) {
				return previous.getId().localeCompare(next.getId());
			});

			return sortedPlayables;
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

	var module = {
		getPlayer: function(name) {
			return new Player(name);
		},
		getPlaylist: function(name) {
			return new Playlist(name);
		},
		getAudio: function(title, author, length) {
			return new Audio(title, author, length);
		},
		getVideo: function(title, author, imdbRating) {
			return new Video(title, author, imdbRating);
		}
	};

	return module;
}
var solver = solve();
var gotten,
	name = 'Rock and roll',
	plName = 'Banana Rock',
	plAuthor = 'Wombles',
	playlist = solver.getPlaylist(name),
	playable = {
		id: 1,
		name: plName,
		author: plAuthor
	};

playlist.addPlayable(playable);
playlist.removePlayable(playable);
gotten = playlist.getPlayableById(1);
console.log(gotten);