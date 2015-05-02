/*Write a function that finds the youngest person in a given array of persons and prints his/hers full name
 * Each person has properties `firstName`, `lastName` and `age`, as shown:
 ```js
 var persons = [
 { firstName : "Gosho", lastName: "Petrov", age: 32 },
 { firstName : "Bay", lastName: "Ivan", age: 81 }
 ...
 ];
 ```
 */

function solveTask() {
	function generatePersonsArray(count) {

		var count = count || 20;

		var firstNames = ["Ivan", "Dragan", "Petko", "Gosho", "Pesho"];
		var lastNames = ["Ivanov", "Draganov", "Petkov", "Dimitrov", "Aprilov"];
		var ages = [18, 22, 27, 42, 65];

		function getPerson(fname, lname, age) {
			return {
				firstName: fname,
				lastName: lname,
				age: age
			};
		}

		var persons = new Array(count);

		for (var i = 0; i < count; i++) {
			persons[i] = getPerson(
				firstNames[Math.floor((Math.random() * firstNames.length))],
				lastNames[Math.floor((Math.random() * lastNames.length))],
				ages[Math.floor((Math.random() * ages.length))]
			);
		}

		return persons;
	}

	var persons = generatePersonsArray();
	var youngestPerson = persons[0];

	for (var i = 1; i < persons.length; i++) {
		if (youngestPerson.age > persons[i].age) {
			youngestPerson = persons[i];
		}
	}

	console.log(youngestPerson);
}

solveTask();

