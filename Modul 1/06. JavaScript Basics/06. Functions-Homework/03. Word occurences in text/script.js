// Write a function that finds all the occurrences of word in a text.
// * The search can case sensitive or case insensitive
// * Use function overloading

function solveTask(text, word, sensitive) {
	var caseSens = sensitive || false;
	var newStr = text.replace(/\W+/g, ' ');
	var words = newStr.split(' ');
	var occurrences = 0;

	if (caseSens) {
		for (var i = 0; i < words.length; i++) {
			if (words[i] === word) {
				occurrences++;
			}
		}
	}
	else {
		var lowerCase = word.toLowerCase();

		for (var j = 0; j < words.length; j++) {
			if (words[i].toLowerCase() == lowerCase) {
				occurrences++;
			}
		}
	}

	return occurrences;
}

console.log(solveTask('hello hello hello this is a list of different words that it is', 'hello', true));