var location1 = 3, location2 = 4, location3 = 5;
var currGuess;
var numberOfHits = 0, numberOfGuesses = 0;
var isSunk = false;

while (!isSunk) {
	currGuess = prompt("Ready, aim, fire! (enter a number 0-6):");

	// Input validity
	if (currGuess < 0 || currGuess > 6) {
		alert("Please enter a valid cell number!");
	}
	else {
		numberOfGuesses++;

		// Hit action
		if (currGuess == location1 || currGuess == location2 || currGuess == location3) {
			numberOfHits++;
			alert("HIT!");
			// Are there 3 hits?
			if (numberOfHits == 3) {
				isSunk = true;
				alert("You sank my battleship!");
			}
		} else {
			alert("MISS!");
		}
	}
}

var stats = "You took " + numberOfGuesses + " guesses to sink the battleship, " +
	"which means your shooting accuracy was " + (3 / numberOfGuesses);
alert(stats);