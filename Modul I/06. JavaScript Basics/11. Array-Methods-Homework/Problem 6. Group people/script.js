function Person(fname, lname, age, gender) {
	this.firstName = fname;
	this.lastName = lname;
	this.age = age;
	this.gender = !gender ? 'male' : 'female';
}

function compareFirstName(a, b) {
	if (a.firstName < b.firstName) {
		return -1;
	}

	if (a.firstName > b.firstName) {
		return 1;
	}

	return 0;
}

function printGroupedPeople(arr) {
	var result = {};
	arr = arr.sort(compareFirstName);
	arr.forEach(function (element) {
		result[element.firstName.charAt(0).toLowerCase()] = {firstname: element.firstName};
	});

	return JSON.stringify(result);
}

var arr = [
	new Person('Doncho', 'Minkov', 25, false),
	new Person('Nikolay', 'Kostov', 24, false),
	new Person('Ivaylo', 'Kenov', 26, false),
	new Person('Pavel', 'Kolev', 25, false),
	new Person('Teodor', 'Kurtev', 23, false),
	new Person('Blagovest', 'Chavdarov', 125, false),
	new Person('Anna', 'Ivanova', 16, true),
	new Person('Iliana', 'Simeonova', 45, true),
	new Person('Svetlana', 'Dragoeva', 18, true),
	new Person('Elica', 'Stoyanova', 13, true)
];

console.log(printGroupedPeople(arr));