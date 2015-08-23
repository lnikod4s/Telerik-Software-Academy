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
		var sortedBooksByDescending =
			_.chain(books)
				.map(function (book) {
					book.author = book.author.firstName + ' ' + book.author.lastName;
					return book;
				})
				.groupBy('author')
				.sortBy(function (group) {
					return group.length;
				})
				.reverse()
				.value();

		var maxBooks = _.first(sortedBooksByDescending).length;

		_.chain(sortedBooksByDescending)
			.filter(function (book) {
				return book.length === maxBooks;
			})
			.map(function (book) {
				return book[0].author;
			})
			.sortBy()
			.each(function (author) {
				console.log(author);
			})
			.value();
	};
}

module.exports = solve;