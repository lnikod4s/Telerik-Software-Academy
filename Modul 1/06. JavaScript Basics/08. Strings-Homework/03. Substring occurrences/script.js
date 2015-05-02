function solveTask() {
	function allOccurrencesLength(str, pattern, isCaseSensitive) {
		var modifier = isCaseSensitive ? "g" : "gi";
		var regex = new RegExp(pattern, modifier);

		return str.match(regex).length;
	}

	var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
	var searchedSubstring = "in";
	var count = allOccurrencesLength(text, searchedSubstring, false);

	console.log(count);
}

solveTask();