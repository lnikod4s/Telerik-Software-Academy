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
//                  Validator object                      //
////////////////////////////////////////////////////////////

var validator = {
	validateString: function(obj) {
		if (!(typeof obj === 'string' || obj instanceof String)) {
			throw new Error('The passed parameter is not a string.');
		}
	},
	validateDOMElement: function(obj) {
		if (!(isNode(obj) || isElement(obj))) {
			throw new Error('The passed parameter is not a valid DOM Element.');
		}
	},
	validateMissingParameters: function(param1, param2) {
		if (param1 === undefined || param2 === undefined) {
			throw new Error('Function parameter is missing.');
		}
	}
};

////////////////////////////////////////////////////////////
//                  Helper methods                        //
////////////////////////////////////////////////////////////

function isNode(obj) {
	return (typeof Node === "object" ? obj instanceof Node :
		obj &&
		typeof obj === "object" &&
		typeof obj.nodeType === "number" &&
		typeof obj.nodeName === "string"
	);
}

function isElement(obj) {
	return (typeof HTMLElement === "object" ?
		obj instanceof HTMLElement : //DOM2
		obj &&
		typeof obj === "object" &&
		obj !== null &&
		obj.nodeType === 1 &&
		typeof obj.nodeName === "string"
	);
}

////////////////////////////////////////////////////////////
//                      Module                            //
////////////////////////////////////////////////////////////

module.exports = function() {
	return function(element, contents) {
		validator.validateString(element);
		validator.validateDOMElement(element);
		validator.validateMissingParameters(element, contents);

		// The first parameter is an id
		if (!(isNode(element) || isElement(element))) {
			var selectedElement = document.getElementById(element);
			selectedElement.innerHTML = '';
		}
	};
};