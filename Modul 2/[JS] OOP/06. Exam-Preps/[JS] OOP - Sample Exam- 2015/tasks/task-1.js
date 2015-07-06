function solve() {
	var Player = (function() {
		var Player = {
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

				return this;
			},
			listPlaylists: function(page, size) {
				// TODO: Implement method
			}
		};
		return Player;
	}());

	var Playlist = (function() {
		var Playlist = {
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

		return Playlist;
	}());

	var Playable = (function() {
		var Playable = {
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

		return Playable;
	}());

	var Audio = (function(parent) {
		var Audio = Object.create(parent);
		Audio = {
			get length() {
				return this._length;
			},
			set length(value) {
				this._length = value;
			},
			init: function(id, title, author, length) {
				parent.init.call(this, id, title, author);
				this.length = length;

				return this;
			},
			play: function() {
				var baseResult = parent.play.call(this);
				baseResult += ' - ' + this.length;

				return baseResult;
			}
		};

		return Audio;
	}(Playable));

	var Video = (function(parent) {
		var Video = Object.create(parent);
		Video = {
			get imdbRating() {
				return this._imdbRating;
			},
			set imdbRating(value) {
				this._imdbRating = value;
			},
			init: function(id, title, author, imdbRating) {
				parent.init.call(this, id, title, author);
				this.imdbRating = imdbRating;

				return this;
			},
			play: function() {
				var baseResult = parent.play.call(this);
				baseResult += ' - ' + this.imdbRating;

				return baseResult;
			}
		};

		return Video;
	}(Playable));
}

module.exports = solve;