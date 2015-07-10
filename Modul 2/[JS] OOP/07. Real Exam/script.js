function solve() {
	var Item,
		Book,
		Media,
		Catalog,
		MediaCatalog,
		BookCatalog,
		CONSTANTS,
		validator;

	CONSTANTS = {
		NAME_MIN_LENGTH: 2,
		NAME_MAX_LENGTH: 40,
		ISBN_MIN_LENGTH: 10,
		ISBN_MAX_LENGTH: 13,
		GENRE_MIN_LENGTH: 2,
		GENRE_MAX_LENGTH: 20

	};

	validator = {
		validateNonEmptyString: function(value, variableName) {
			if (!(typeof value === 'string' || value instanceof String)) {
				throw new Error(variableName + ' should be a string.');
			}

			if (!value.length) {
				throw new Error(variableName + ' should be non-empty string.');
			}
		},
		validateNameLength: function(value, variableName) {
			if (!(typeof value === 'string' || value instanceof String)) {
				throw new Error(variableName + ' should be a string.');
			}

			if (value.length < CONSTANTS.NAME_MIN_LENGTH || value.length > CONSTANTS.NAME_MAX_LENGTH) {
				throw new Error(variableName + ' should be a string with length between ' +
				                CONSTANTS.NAME_MIN_LENGTH + ' and ' +
				                CONSTANTS.NAME_MAX_LENGTH);
			}
		},
		validateIsbnLength: function(value, variableName) {
			if (!(typeof value === 'string' || value instanceof String)) {
				throw new Error(variableName + ' should be a string.');
			}

			if (!(value.length == CONSTANTS.ISBN_MIN_LENGTH || value.length == CONSTANTS.ISBN_MAX_LENGTH)) {
				throw new Error(variableName + ' should be a string with length exactly ' +
				                CONSTANTS.ISBN_MIN_LENGTH + ' or ' +
				                CONSTANTS.ISBN_MAX_LENGTH);
			}
		},
		validateGenreLength: function(value, variableName) {
			if (!(typeof value === 'string' || value instanceof String)) {
				throw new Error(variableName + ' should be a string.');
			}

			if (value.length < CONSTANTS.GENRE_MIN_LENGTH || value.length > CONSTANTS.GENRE_MAX_LENGTH) {
				throw new Error(variableName + ' should be a string with length between ' +
				                CONSTANTS.GENRE_MIN_LENGTH + ' and ' +
				                CONSTANTS.GENRE_MAX_LENGTH);
			}
		},
		validateNonEmptyArray: function(array, variableName) {
			if (!array.length) {
				throw new Error(variableName + ' should be a non-empty array.');
			}
		},
	};

	// -------------------------- Helper Functions --------------------------
	Object.prototype.extend = function(parent) {
		this.prototype = Object.create(parent.prototype);
		this.prototype.constructor = this;
	};

	function isInteger(x) {
		return ((x ^ 0) === x);
	}

	function removeDuplicateItems(array) {
		var object = {};
		for (var i = 0; i < array.length; i++) {
			object[array[i]] = true;
		}

		var r = [];
		for (var k in object) {
			r.push(k)
		}

		return r;
	}
	// **********************************************************************

	Item = (function() {
		var itemId = 0;

		function Item(name, description) {

			this.setName(name);
			this.setDescription(description);
			this.id = ++itemId;
		}

		Item.prototype.getName = function() {
			return this._name;
		};

		Item.prototype.setName = function(value) {
			validator.validateNonEmptyString(value, 'Name');
			this._name = value;
		};

		Item.prototype.getDescription = function() {
			return this._description;
		};

		Item.prototype.setDescription = function(value) {
			validator.validateNameLength(value, 'Description');
			this._description = value;
		};

		return Item;
	}());

	Book = (function(parent) {
		function Book(name, isbn, genre, description) {
			parent.call(this, name, description);
			this.setIsbn(isbn);
			this.setGenre(genre);
		}

		Book.extend(parent);

		Book.prototype.getIsbn = function() {
			return this._isbn;
		};

		Book.prototype.setIsbn = function(value) {
			validator.validateIsbnLength(value, 'ISBN');
			this._isbn = value;
		};

		Book.prototype.getGenre = function() {
			return this._genre;
		};

		Book.prototype.setGenre = function(value) {
			validator.validateNameLength(value, 'Description');
			this._genre = value;
		};

		return Book;
	}(Item));

	Media = (function(parent) {
		function Media(name, rating, duration, description) {
			parent.call(this, name, description);
			this.setRating(rating);
			this.setDuration(duration);
		}

		Media.extend(parent);

		Media.prototype.getRating = function() {
			return this._rating;
		};

		Media.prototype.setRating = function(value) {
			if (!isInteger(value)) {
				throw new Error('Rating must be an integer');
			}

			if (value < 1 || value > 5) {
				throw new Error('Rating must be an integer between 1 and 5');
			}
			
			this._rating = value;
		};

		Media.prototype.getDuration = function() {
			return this._duration;
		};

		Media.prototype.setDuration = function(value) {
			if (!isInteger(value)) {
				throw new Error('Duration must be an integer');
			}
			
			if (value <= 0) {
				throw new Error('Duration must be an integer greater than 0');
			}

			this._duration = value;
		};

		return Media;
	}(Item));

	Catalog = (function() {
		var catalogId = 0;

		function Catalog(name) {
			this.setName(name);
			this._items = [];
			this.id = ++catalogId;
		}

		Catalog.prototype.getName = function() {
			return this._name;
		};

		Catalog.prototype.setName = function(value) {
			validator.validateNonEmptyString(value, 'Name');
			this._name = value;
		};

		Catalog.prototype.add = function(items) {
			if (items === undefined) {
				throw new Error('No items are passed');
			}

			items = Array.prototype.slice.call(arguments);
			if (!items.length) {
				throw new Error('Items array must be non-empty');
			}

			items.forEach(function(item) {
				var currItem = item;
				if (!(currItem instanceof Item)) {
					throw new Error('Item is not an Item instance or not an Item-like object');
				}
			});

			this._items = items.slice(0);
		};

		Catalog.prototype.find = function(options) {
			var result;
			if (typeof options === 'object') {
				result = [];
				var currId = options['id'];
				var currName = options['name'];

				for (var j = 0; j < this._items.length; j++) {
					var item = this._items[j];
					var itemId = item.id;
					var itemName = item.getName();
					if (itemId == currId || itemName == currName) {
						result.push(item);
					}
				}
			} else {
				if (!isInteger(options)) {
					throw new Error('Id must a number');
				}

				for (var i = 0; i < this._items.length; i++) {
					var currItem = this._items[i];
					if (currItem.id === options) {
						result = currItem;
					}
				}

				result = null;
			}

			return result;
		};

		Catalog.prototype.search = function(pattern) {
			validator.validateNonEmptyString(pattern, 'Pattern');
			if (pattern.length < 1) {
				throw new Error('The pattern is a string and should contains at least 1 character');
			}

			var result = [];
			pattern = pattern.toLowerCase();
			for (var i = 0; i < this._items.length; i++) {
				var currItem = this._items[i];
				var currItemName = currItem.getName().toLowerCase();
				var currItemDescription = currItem.getDescription().toLowerCase();
				if (currItemName.indexOf(pattern) > -1 || currItemDescription.indexOf(pattern) > -1) {
					result.push(currItem);
				}
			}

			return result;
		};

		return Catalog;
	}());

	BookCatalog = (function(parent){
		function BookCatalog(name) {
			parent.call(this, name);
		}

		BookCatalog.extend(parent);

		BookCatalog.prototype.add = function(books) {
			parent.prototype.add.call(this, books);
			this._items.forEach(function(book) {
				if (!(book instanceof Book)) {
					throw new Error('Invalid book');
				}
			});
		};

		BookCatalog.prototype.getGenres = function() {
			var result = [];
			for (var i = 0; i < this._items.length; i++) {
				var currItem = this._items[i];
				var currGenre = currItem.getGenre().toLowerCase();
				result.push(currGenre);
			}

			return removeDuplicateItems(result);
		};

		BookCatalog.prototype.find = function(options) {
			var result = Catalog.prototype.find.call(this, options);
			var key = options['key'];

			for (var i = 0; i < this._items.length; i++) {
				var currItem = this._items[i];
				if (currItem.hasOwnProperty(key)) {
					result.push(currItem);
				}
			}

			return result;
		};

		return BookCatalog;
	}(Catalog));

	MediaCatalog = (function(parent){
		function MediaCatalog(name) {
			parent.call(this, name);
		}

		MediaCatalog.extend(parent);

		MediaCatalog.prototype.add = function(media) {
			parent.prototype.add.call(this, media);
			media.forEach(function(book) {
				if (!(Media.isPrototypeOf(media))) {
					throw new Error('Invalid book');
				}
			});
		};

		MediaCatalog.prototype.getTop = function(count) {
			if (!isInteger(count) && count < 1) {
				throw new Error('Invalid count');
			}
		};

		return MediaCatalog;
	}(Catalog));

	return {
		getBook: function(name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function(name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function(name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function(name) {
			return new MediaCatalog(name);
		}
	};
}
var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

catalog.find(book1.id);
//returns book1

//console.log(catalog.find({id: book2.id, genre: 'IT'}));
////returns book2
//
//console.log(catalog.search('js'));
//// returns book2
//
//console.log(catalog.search('javascript'));
////returns book1 and book2
//
//console.log(catalog.search('Te sa zeleni'));
////returns []