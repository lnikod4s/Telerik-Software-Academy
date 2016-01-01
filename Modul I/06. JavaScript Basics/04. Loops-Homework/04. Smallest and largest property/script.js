// Write a script that finds the lexicographically smallest and largest property in document, window and navigator
// objects

function solveTask(objects) {
	for (var object in objects) {
		var properties = [];
		
		for (var property in objects[object]) {
			properties.push(property);
		}

		properties.sort();
		
		console.log('Smallest property: ' + properties.shift());
		console.log('Largest property: ' + properties.pop());
		console.log(new Array(11).join('-'));
	}
}

solveTask([document, window, navigator]);