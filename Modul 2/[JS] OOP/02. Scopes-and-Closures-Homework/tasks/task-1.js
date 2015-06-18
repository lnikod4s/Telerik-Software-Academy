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
			categories = [],
			filtered = [];

		// Helper functions
		function isNumber(n) {
			return !isNaN(parseFloat(n)) && isFinite(n);
		}

		function listBooks() {
			var args = arguments[0];

			if (books.length === 0) {
				return [];
			}

			if (books.length === 1) {
				if (!args || books[0].category === args.category) {
					return books;
				}

				return [];
			}

			if (args) {
				filtered = books.filter(function(b) {
					return b.category === args.category;
				});
			}
			else {
				filtered = books;
			}

			return filtered.sort(function(a, b) {
				return a.id - b.id;
			})

		}

		function addBook(book) {
			if (books.some(checkForRepeatingTitle)) {
				throw  new Error('Adding a book title that already exists is not allowed.');
			}

			if (books.some(checkForRepeatingISBN)) {
				throw  new Error('Adding a book ISBN that already exists is not allowed.');
			}

			if (!book.category) {
				book.category = '';
			}

			if (book.title && (book.title.length < 2 || book.title.length > 100)) {
				throw  new Error('Book title must be between 2 and 100 characters.');
			}

			if (!book.author) {
				throw  new Error('Author must be a non-empty string.');
			}

			if (!(book.isbn.length === 10 || book.isbn.length === 13)) {
				throw  new Error('Book ISBN must be either 10 or 13 digits.');
			}

			if (!isNumber(book.isbn)) {
				throw  new Error('Book ISBN must be a number.');
			}

			book.id = books.length + Math.floor(Math.random() * 11);
			books.push(book);

			var newCategory = {
				category: book.category,
				ID: categories.length + Math.floor(Math.random() * 11)
			};

			if (categories.length === 0) {
				categories.push(newCategory);
			} else if (categories && !categories.some(function(elem) {
					return elem.category === newCategory.category;
				})) {
				categories.push(newCategory);
			}

			return book;

			function checkForRepeatingISBN(existingBook) {
				if (books.length === 0) {
					return false;
				}

				return existingBook.isbn === book.isbn;
			}

			function checkForRepeatingTitle(existingBook) {
				if (books.length === 0) {
					return false;
				}

				return existingBook.title === book.title;
			}
		}

		function listCategories() {
			categories.sort(function(a, b) {
				return a.id - b.id;
			});

			return categories.map(function(element) {
				return element.category;
			})
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