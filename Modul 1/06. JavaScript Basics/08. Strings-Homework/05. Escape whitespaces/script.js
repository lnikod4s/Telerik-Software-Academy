function solveTask() {
	var text = "This is   an example .";
	var newSubstring = "&nbsp;";

	console.log(text);
	var result = text.replace(/ /g, newSubstring);
	console.log(result);
}

solveTask();