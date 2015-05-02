// Write a function that makes a deep copy of an object. The function should work for both primitive and reference
// types.

function solveTask() {
	function makeDeepCopy(obj) {
		return JSON.parse(JSON.stringify(obj));
	}

	var pesho = {
		name: "Pesho",
		age: 16,
		objProp: {prop1: 4, prop2: 7}
	};

	var deepCopy = makeDeepCopy(pesho);
	console.log(deepCopy);
}

solveTask();