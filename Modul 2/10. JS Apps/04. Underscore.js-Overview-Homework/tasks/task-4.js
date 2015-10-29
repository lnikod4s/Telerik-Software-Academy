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
	return function (animals) {
		/* ======= Underscore Mixin ======= */
		_.mixin({
			repeat: function (times, str) {
				if (!times) {
					times = 1;
				}

				var repeatedString = '';
				for (var i = 0; i < times; i += 1) {
					repeatedString += str;
				}

				return repeatedString;
			}
		});

		var groupedAnimals = _.chain(animals)
			.sortBy('species')
			.reverse()
			.groupBy('species')
			.value();

		_.each(groupedAnimals, function (item, index) {
			var group = _.sortBy(item, 'legsCount');

			console.log(_.repeat(index.length + 1, '-'));
			console.log(index + ':');
			console.log(_.repeat(index.length + 1, '-'));
			_.each(group, function (item, index) {
				console.log(item.name + ' has ' + item.legsCount + ' legs');
			})
		});
	};
}

module.exports = solve;