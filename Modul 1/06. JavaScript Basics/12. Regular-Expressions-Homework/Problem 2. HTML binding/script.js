String.prototype.insertAt = function (index, string) {
	return [this.slice(0, index), string, this.slice(index)].join('');
};

String.prototype.bind = function (attr) {
	var str = this,
		regex = /(?:data\-bind\-(\w+)="(\w+)")/g,
		match,
		matches = {};

	while (match = regex.exec(str)) {
		matches[match[1]] = match[2];
	}

	for (var key in matches) {
		if (matches.hasOwnProperty(key)) {
			if (key === 'content') {
				var angleBracketIndex = str.indexOf('>');
				str = str.insertAt(angleBracketIndex + 1, attr[matches[key]]);
			} else {
				var doubleQuotesIndex = str.lastIndexOf('\"');
				str = str.insertAt(doubleQuotesIndex + 1, ' ' + key + '\"=' + attr[matches[key]] + '\"');
			}
		}
	}

	return str;
};

var attributes1 = {name: 'Steven'};
console.log('<div data-bind-content="name"></div>'.bind(attributes1));

var attributes2 = {name: 'Elena', link: 'http://telerikacademy.com'};
console.log('<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></\a>'.bind(attributes2));