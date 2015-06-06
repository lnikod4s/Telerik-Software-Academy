// Invoke replace callback function, that takes input string and first match as parameters
String.prototype.format = function (options) {
	return this.replace(/(?:#{(\w+)})/g, function ($0, $1) {
		return options[$1];
	});
};

var options1 = {name: 'John'};
console.log('Hello, there! Are you #{name}?'.format(options1));

var options2 = {name: 'John', age: 13};
console.log('My name is #{name} and I am #{age}-years-old'.format(options2));