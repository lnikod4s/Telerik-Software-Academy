function generatePersonsArray(count) {

	var count = count || 20;

	var names = ["Ivan", "Dragan", "Petko", "Gosho", "Pesho","Milena"];
	var ages = [18, 22, 27,33, 42, 65];

	function getPerson(fname, age) {
		return {
			name: fname,
			age: age,
		};
	}

	var persons = new Array(count);

	for (var i = 0; i < count; i++) {
		persons[i] = getPerson(
			names[Math.floor((Math.random() * names.length))],
			ages[Math.floor((Math.random() * ages.length))]
		);
	}

	return persons;
}