/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique name, author and ISBN
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	Add new category
 *	Each category has a unique name
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/category has a unique identifier (ID) that is a number greater than 1
 *	When adding a book/category, the is generated automatically
 *	Add validation everywhere, where possible
 *	Book and category names must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Unique params are Book name, Category name, and Book ISBN
 * Book authors can be repeated
 *	If something is not valid - throw Error
 */
function solve() {
	var library = (function() {
		var books = [],
			newBooks = [],
			categories = [],
			filter = '';

		function containsBookTitle(obj, arr) {
			var i;
			for (i = 0; i < arr.length; i++) {
				if (arr[i].title === obj.title) {
					return true;
				}
			}

			return false;
		}

		function containsBookISBN(obj, arr) {
			var i;
			for (i = 0; i < arr.length; i++) {
				if (arr[i].isbn === obj.isbn) {
					return true;
				}
			}

			return false;
		}

		function generateID() {
			var date,
				components;

			date = new Date();
			components = [
				date.getYear(),
				date.getMonth(),
				date.getDate(),
				date.getHours(),
				date.getMinutes(),
				date.getSeconds(),
				date.getMilliseconds()
			];

			return Number(components.join(""));
		}

		function listBooks() {
			if (books.length === 0) {
				return [];
			}

			if (books.length === 1) {
				delete books[0].id;
				return [books[0]];
			}

			if (arguments !== undefined) {
				if (arguments[0].category !== undefined) {
					filter = arguments[0].category;

					for (var i = 0, len = books.length; i < len; i += 1) {
						if (books[i].category === filter) {
							newBooks.push(books[i]);
						}
					}

					if (newBooks.length === 0) {
						return [];
					}

					books = newBooks.slice();
					newBooks = [];
					filter = '';
				}

				if (arguments[0].author !== undefined) {
					filter = arguments[0].author;

					for (var j = 0, len2 = books.length; j < len2; j += 1) {
						if (books[i].author === filter) {
							newBooks.push(books[j]);
						}
					}

					if (newBooks.length === 0) {
						return [];
					}

					books = newBooks.slice();
					newBooks = [];
					filter = '';
				}
			}

			books = books.sort(function(a, b) {
				return a.id - b.id;
			});

			return books;
		}

		function addBook(bookToAdd) {
			if (bookToAdd.title.length < 2 || bookToAdd.title.length >= 100) {
				throw new Error('Invalid book title.');
			}

			if (bookToAdd.category.length < 2 || bookToAdd.category.length >= 100) {
				throw new Error('Invalid book category.');
			}
			
			if (bookToAdd.author === '' || bookToAdd.author === undefined) {
				throw new Error('Invalid book author.');
			}

			if (bookToAdd.isbn.length < 10 || bookToAdd.isbn.length > 13) {
				throw new Error('Invalid book ISBN.');
			}

			var newBook = {
				title: bookToAdd.title,
				author: bookToAdd.author,
				isbn: bookToAdd.isbn,
				category: bookToAdd.category,
				id: generateID()
			};

			if (containsBookTitle(newBook, books)) {
				throw new Error('Books with repeating titles are not allowed.');
			}

			if (containsBookISBN(newBook, books)) {
				throw new Error('Books with repeating ISBN are not allowed.');
			}

			books.push(newBook);
			categories.push(newBook.category);

			return newBook;
		}

		function listCategories() {
			if (categories.length === 0) {
				return [];
			}

			categories = categories.sort(function(a, b) {
				return a.id - b.id;
			});

			categories = categories.reduce(function(a, b) {
				if (a.indexOf(b) < 0) {
					a.push(b);
				}
				return a;
			}, []);

			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	}());

	return library;
}

module.exports = solve;