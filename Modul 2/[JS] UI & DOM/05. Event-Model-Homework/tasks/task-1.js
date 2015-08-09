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
	validateExistingId: function(id) {
		if (!isExistingId(id)) {
			throw new Error('The provided id does not select anything.');
		}
	},

	validateParams: function(selector) {
		if (!isString(selector) && !isHTMLElement(selector)) {
			throw new Error('The provided id is not a string or does not select any DOM element.');
		}
	}
};

////////////////////////////////////////////////////////////
//                  Helper Functions                      //
////////////////////////////////////////////////////////////

function isHTMLElement(obj) {
	return typeof obj === 'object' && obj instanceof Element;
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
	var validator = {
		validateExistingId: function(id) {
			if (!isExistingId(id)) {
				throw new Error('The provided id does not select anything.');
			}
		},

		validateParams: function(selector) {
			if (!isString(selector) && !isHTMLElement(selector)) {
				throw new Error('The provided id is not a string or does not select any DOM element.');
			}
		}
	};

	function isHTMLElement(obj) {
		return typeof obj === 'object' && obj instanceof Element;
	}

	function isString(obj) {
		return typeof obj == 'string' || obj instanceof String;
	}

	function isExistingId(id) {
		var element = document.getElementById(id);
		return typeof element !== 'undefined' && element !== null;
	}

	return function(selector) {
		// Validations
		validator.validateParams(selector);
		validator.validateExistingId(selector);

		// Select all buttons and change their content to 'hide'
		var buttons = document.getElementsByClassName('button');
		for (var i = 0, len = buttons.length; i < len; i++) {
			buttons[i].innerHTML = 'hide';
		}

		// Iterate over all buttons and implement onclick functionality
		for (i = 0, len = buttons.length; i < len; i++) {
			var currButton = buttons[i];

			currButton.addEventListener('click', function(ev) {
				var clickedButton = ev.target;
				var nextContent = clickedButton.nextElementSibling;
				while (nextContent && nextContent.className.indexOf('content') < 0) {
					nextContent = nextContent.nextElementSibling;
				}

				var isContentVisible = nextContent.style.display === '';
				if (isContentVisible) {
					nextContent.style.display = 'none';
					clickedButton.innerHTML = 'show';
				} else {
					nextContent.style.display = ''; // <=> display: block;
					clickedButton.innerHTML = 'hide';
				}
			});
		}
	};
}

module.exports = solve;