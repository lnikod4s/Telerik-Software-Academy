/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element with the specified id
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neither `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

////////////////////////////////////////////////////////////
//                      Validator                         //
////////////////////////////////////////////////////////////

var validator = {
	validateDOMElement: function(obj) {
		if (!(isString(obj) || isHTMLElement(obj))) {
			throw new Error('The passed parameter is not a valid DOM Element.');
		}
	},

	validateMissingParameters: function(param1, param2) {
		if (param1 === undefined || param2 === undefined) {
			throw new Error('Function parameter is missing.');
		}
	},

	validateContents: function(contents) {
		if (contents.some(function(content) {
				return !isString(content) && !isNumber(content);
			})) {
			throw new Error('The array should contains only strings and numbers');
		}
	}
};

////////////////////////////////////////////////////////////
//                  Helper methods                        //
////////////////////////////////////////////////////////////

function isString(obj) {
	return typeof obj == 'string' || obj instanceof String;
}

function isHTMLElement(obj) {
	return obj instanceof HTMLElement;
}

function isNumber(obj) {
	return typeof obj == 'number' || obj instanceof Number;
}

////////////////////////////////////////////////////////////
//                      Module                            //
////////////////////////////////////////////////////////////

function solve() {
	var validator = {
		validateDOMElement: function(obj) {
			if (!(isString(obj) || isHTMLElement(obj))) {
				throw new Error('The passed parameter is not a valid DOM Element.');
			}
		},

		validateMissingParameters: function(param1, param2) {
			if (param1 === undefined || param2 === undefined) {
				throw new Error('Function parameter is missing.');
			}
		},

		validateContents: function(contents) {
			if (contents.some(function(content) {
					return !isString(content) && !isNumber(content);
				})) {
				throw new Error('The array should contains only strings and numbers');
			}
		}
	};

	function isString(obj) {
		return typeof obj == 'string' || obj instanceof String;
	}

	function isHTMLElement(obj) {
		return obj instanceof HTMLElement;
	}

	function isNumber(obj) {
		return typeof obj == 'number' || obj instanceof Number;
	}

	return function(element, contents) {
		var selectedElement,
			currFirstChild,
			divElement,
			documentFragment,
			currDiv;

		// Validations
		validator.validateMissingParameters(element, contents);
		validator.validateDOMElement(element);

		// The first parameter is an id
		if (isString(element)) {
			selectedElement = document.getElementById(element);
		} else { // The first parameter is a regular DOM element
			selectedElement = element;
		}

		// Additional validation
		validator.validateContents(contents);

		// Removing all children
		// .innerHTML = '' works only when dealing with HTML elements
		currFirstChild = selectedElement.firstChild;
		while (currFirstChild) {
			selectedElement.removeChild(currFirstChild);
			currFirstChild = selectedElement.firstChild;
		}

		// Appends div elements to selectedElement
		divElement = document.createElement('div');
		documentFragment = document.createDocumentFragment();

		for (var i = 0, len = contents.length; i < len; i++) {
			currDiv = divElement.cloneNode(true); // Performs a deep copy
			currDiv.innerHTML = contents[i];
			documentFragment.appendChild(currDiv);
		}

		selectedElement.appendChild(documentFragment);
	};
}

module.exports = solve;