/* 
 Create a function that:
 *   **Takes** an array of animals
 *   Each animal has properties `name`, `species` and `legsCount`
 *   **groups** the animals by `species`
 *   the groups are sorted by `species` descending
 *   **sorts** them ascending by `legsCount`
 *	if two animals have the same number of legs sort them by name
 *   **prints** them to the console in the format:

 ```
 ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
 GROUP_1_NAME:
 ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
 NAME has LEGS_COUNT legs //for the first animal in group 1
 NAME has LEGS_COUNT legs //for the second animal in group 1
 ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
 GROUP_2_NAME:
 ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
 NAME has LEGS_COUNT legs //for the first animal in the group 2
 NAME has LEGS_COUNT legs //for the second animal in the group 2
 NAME has LEGS_COUNT legs //for the third animal in the group 2
 NAME has LEGS_COUNT legs //for the fourth animal in the group 2
 ```
 *   **Use underscore.js for all operations**
 */

function solve() {
	if (!String.prototype.repeat) {
		String.prototype.repeat = function (times) {
			if (!times) {
				times = 1;
			}

			var repeatedString = '';
			for (var i = 0; i < times; i += 1) {
				repeatedString += String(this);
			}

			return repeatedString;
		};
	}
	
	return function (animals) {
		var groupedAnimals = _.chain(animals)
			.sortBy('species')
			.reverse()
			.groupBy('species')
			.value();

		for (var key in groupedAnimals) {
			var group = _.chain(groupedAnimals[key])
				.sortBy('legsCount')
				.value();

			console.log('-'.repeat(key.length + 1));
			console.log(key + ':');
			console.log('-'.repeat(key.length + 1));
			for (var animal in group) {
				console.log(group[animal].name + ' has ' + group[animal].legsCount + ' legs');
			}

		}
	};
}

module.exports = solve;