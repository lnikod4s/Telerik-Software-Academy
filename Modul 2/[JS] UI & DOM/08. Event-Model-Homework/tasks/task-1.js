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
	validateId: function(id) {
		if (!isExistingId(id)) {
			throw new Error('The provided id does not select anything.');
		}
	},

	validateSelector: function(selector) {
		if (!isString(selector) && !isHTMLElement(selector)) {
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

////////////////////////////////////////////////////////////
//                  Solving Function                      //
////////////////////////////////////////////////////////////
function solve() {
	return function(selector) {
		// Validations
		validator.validateSelector(selector);
		validator.validateId(selector);

		var buttonElements = document.getElementsByClassName('button');
		for (var i = 0, len = buttonElements.length; i < len; i++) {
			var currButton = buttonElements[i];
			currButton.innerHTML = 'hide';
			currButton.addEventListener('click', function(ev) {
				var clickedElement = ev.target;
				var nextSibling = clickedElement.nextElementSibling;
				var isValid;

				while (nextSibling) {
					// Next sibling has class 'button'
					if (nextSibling.className == 'button') {
						nextSibling = nextSibling.nextElementSibling;
					} else { // Next sibling has class 'content'
						var topmostContentElement = nextSibling;
						nextSibling = nextSibling.nextSibling;

						while (nextSibling) {
							if (nextSibling.className == 'button') {
								isValid = true;
							}

							nextSibling = nextSibling.nextElementSibling;
						}

						break;
					}
				}

				if (isValid) {
					if (topmostContentElement.style.display == 'none') {
						topmostContentElement.style.display = ''; // display: block;
						clickedElement.innerHTML = 'hide';
					} else {
						topmostContentElement.style.display = 'none';
						clickedElement.innerHTML = 'show';
					}
				}
			});
		}
	};
}

module.exports = solve;