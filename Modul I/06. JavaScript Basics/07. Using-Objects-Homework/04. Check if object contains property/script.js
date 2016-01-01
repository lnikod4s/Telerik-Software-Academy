/*Write a function that checks if a given object contains a given property
 ```js
 var obj  = ...;
 var hasProp = hasProperty(obj, "length");
 ```
 */

function solveTask(obj, prop) {
	if (obj[prop]) {
		console.log('The object contains given property.');
	}
	else {
		console.log('Sorry! No such property.');
	}
}

solveTask(pesho = {
	name: 'Pesho',
	age: 16,
	objProp: {prop1: 4, prop2: 7}
}, 'value');