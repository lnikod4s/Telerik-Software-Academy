/* 
 Create a function that:
 *   **Takes** a collection of books
 *   Each book has properties `title` and `author`
 **  `author` is an object that has properties `firstName` and `lastName`
 *   **finds** the most popular author (the author with biggest number of books)
 *   **prints** the author to the console
 *	if there is more than one author print them all sorted in ascending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
	return function (books) {
		_.mixin({
			'sortKeysBy': function (obj, comparator) {
				var keys = _.sortBy(_.keys(obj), function (key) {
					return comparator ? comparator(obj[key], key) : key;
				});

				return _.object(keys, _.map(keys, function (key) {
					return obj[key];
				}));
			}
		});

		var authors = _.countBy(books, function (book) {
			return book.author.firstName + ' ' + book.author.lastName;
		});

		var sortedAuthorsByPopularity = _.sortKeysBy(authors, function (value, key) {
			return value;
		});

		return sortedAuthorsByPopularity;
	};
}

module.exports = solve;