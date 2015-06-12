function solve(args) {
	var output = args.slice().join('\n');
	var selectors = {};

	// -------------------------- REMOVE ALL WHITESPACES --------------------------
	output = output.replace(/(;)\n}/g, '\n}');
	output = output.replace(/(\s+)/g, '');

	// -------------------------- MERGE PROPERTIES --------------------------
	output = output.replace(/(.+?)\{(.+?)}/g, function (match, selector, content) {
		var propertyName;
		var propertyValue;
		if (content.indexOf(';') > -1) {
			content = content.split(';');
			selectors[selector] = {};
			for (var i = 0; i < content.length; i += 1) {
				var line = content[i].split(':');
				propertyName = line[0];
				propertyValue = line[1];
				selectors[selector][propertyName] = propertyValue;
			}
		} else {
			content = content.split(':');
			propertyName = content[0];
			propertyValue = content[1];
			selectors[selector][propertyName] = propertyValue;
		}

		if (selectors.hasOwnProperty(selector)) {
			for (var j = 0; j < selectors[selector].length; j += 1) {
				if (selectors[selector][propertyName]) {
					selectors[selector][propertyName] = propertyValue;
				}
			}

			return '';
		} else {
			return match;
		}
	});

	return output;
}

console.log(solve([
	'the-big-b{',
	'	color: yellow;',
	'	size: big;',
	'}',
	'.muppet{',
	'	powers: all;',
	'	skin: fluffy;',
	'}',
	'.water-spirit         {',
	'	powers: water;',
	'	alignment    : not-good;',
	'}',
	'all{',
	'	meant-for: nerdy-children;',
	'}',
	'.muppet      {',
	'	powers: everything;',
	'}',
	'all            .muppet {',
	'	alignment             :             good                             ;',
	'}',
	'.muppet+             .water-spirit{',
	'	power: everything-a-muppet-can-do-and-water;',
	'}'
]));