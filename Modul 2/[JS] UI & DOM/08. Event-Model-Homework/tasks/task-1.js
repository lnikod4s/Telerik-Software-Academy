/* globals $ */

/* 
 ## DOM Operations
 * For instructions on how to run the tests, check the following link:
 * https://github.com/TelerikAcademy/JavaScript-UI-and-DOM/blob/master/README.md#user-content-preparing-the-local-machine-for-unit-testing-with-mocha-and-chai_

 ## Task 1
 Create a function that takes an id or DOM element and:
 * If an id is provided, select the element
 * Finds all elements with class `button` or `content` within the provided element
 * Change the content of all `.button` elements with "hide"
 * When a `.button` is clicked:
 * Find the topmost `.content` element, that is before another `.button` and:
 * If the `.content` is visible:
 * Hide the `.content`
 * Change the content of the `.button` to "show"
 * If the `.content` is hidden:
 * Show the `.content`
 * Change the content of the `.button` to "hide"
 * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
 * Throws if:
 * The provided DOM element is non-existent
 * The id is either not a string or does not select any DOM element
 */

////////////////////////////////////////////////////////////
//                      Validator                         //
////////////////////////////////////////////////////////////

var validator = {
	validateDOMElement: function(obj) {
		if (!isHTMLElement(obj)) {
			throw new Error('The provided DOM Element does not exists.');
		}
	},

	validateExistingId: function(id) {
		if (!isString(id) || !isExistingId(id)) {
			throw new Error('The provided id is not a string or does not select any DOM element.');
		}
	}
};

////////////////////////////////////////////////////////////
//                  Helper Functions                      //
////////////////////////////////////////////////////////////

function isHTMLElement(obj) {
	return obj instanceof HTMLElement;
}

function isString(obj) {
	return typeof obj == 'string' || obj instanceof String;
}

function isExistingId(id) {
	var element = document.getElementById(id);
	return typeof element !== 'undefined' && element !== null;
}

function hasClass(element, cls) {
	return (' ' + element.className + ' ').indexOf(' ' + cls + ' ') > -1;
}

function isHidden(el) {
	var style = window.getComputedStyle(el);
	return (style.display === 'none');
}

function showElement(el) {
	var style = window.getComputedStyle(el);
	style.display = 'block';
}

function hideElement(el) {
	var style = window.getComputedStyle(el);
	style.display = 'none';
}

////////////////////////////////////////////////////////////
//                  Solving Function                      //
////////////////////////////////////////////////////////////
function solve() {
	return function(selector) {
		var selectedElem,
			children = [];

		// Validations
		validator.validateDOMElement(selector);
		validator.validateExistingId(selector);

		// ID is provided
		if (!isHTMLElement(selector)) {
			selectedElem = document.getElementById(selector);
		}

		// Iterate over the children of the selected element
		// and find the elements with classes '.button' & '.content'
		children = selectedElem.children;
		for (var i = 0, len = children.length; i < len; i++) {
			var currElem = children[i];
			if (hasClass(currElem, 'button')) {
				currElem.innerText = 'hide';
				currElem.onclick = function onClickButton() {
					var currContentElem = document.querySelector(selector + ' .button + .content');
					if (!isHidden(currContentElem)) {
						hideElement(currContentElem);
						currElem.innerText = 'show';
					} else {
						showElement(currContentElem);
						currElem.innerText = 'hide';
					}
				};
			}
		}
	};
}

module.exports = solve;