function Person(fname, lname, age, gender) {
	this.firstName = fname;
	this.lastName = lname;
	this.age = age;
	this.gender = !gender ? 'male' : 'female';
}

console.log([
	new Person('Doncho', 'Minkov', 25, false),
	new Person('Nikolay', 'Kostov', 24, false),
	new Person('Ivaylo', 'Kenov', 26, false),
	new Person('Pavel', 'Kolev', 25, false),
	new Person('Teodor', 'Kurtev', 23, false),
	new Person('Blagovest', 'Chavdarov', 125, false),
	new Person('Anna', 'Ivanova', 29, true),
	new Person('Iliana', 'Simeonova', 45, true),
	new Person('Svetlana', 'Dragoeva', 56, true),
	new Person('Elica', 'Stoyanova', 78, true)
]);