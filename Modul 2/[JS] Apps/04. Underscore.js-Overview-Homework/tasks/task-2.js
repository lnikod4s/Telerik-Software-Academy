/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName`, `lastName` and `age` properties
 *   **finds** the students whose age is between 18 and 24
 *   **prints**  the fullname of found students, sorted lexicographically ascending
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
	return function (students) {
		_.chain(students)
			.map(function (student) {
				student.fullName = student.firstName + ' ' + student.lastName;
				return student;
			})
			.filter(function (student) {
				return student.age >= 18 && student.age <= 24;
			})
			.sortBy('fullName')
			.each(function (student) {
				console.log(student.fullName);
			})
	};
}

module.exports = solve;
