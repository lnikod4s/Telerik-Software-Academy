/*Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups. Use function overloading (i.e. just one function).
 ```js
 var persons = { ... };
 var groupedByFirstName = group(persons, "firstname");
 var groupedByAge = group(persons, "age");
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

	function group(arrPersons, key) {
		if (arrPersons.length===0) {
			return undefined;
		}
		var answer = {};
		for (var prop in arrPersons[0]) {
			if (prop === key) {
				for (var i = 0; i < arrPersons.length; i++) {
					if (!answer[arrPersons[i][key]]) {
						answer[arrPersons[i][key]] = [];
					}
					answer[arrPersons[i][key]].push(arrPersons[i]);
				}
			}
		}
		return answer;
	}

	var persons = generatePersonsArray();
	var groupByAge = group(persons, "age");
	var groupByFirstName = group(persons, "firstName");
	var groupByLastName = group(persons, "lastName");

	console.log(groupByAge);
	console.log(groupByFirstName);
	console.log(groupByLastName);
}

solveTask();