/* globals $ */

/* 

 Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:
 * The UL must have a class `items-list`
 * Each of the LIs must:
 * have a class `list-item`
 * content "List item #INDEX"
 * The indices are zero-based
 * If the provided selector does not selects anything, do nothing
 * Throws if
 * COUNT is a `Number`, but is less than 1
 * COUNT is **missing**, or **not convertible** to `Number`
 * _Example:_
 * Valid COUNT values:
 * 1, 2, 3, '1', '4', '1123'
 * Invalid COUNT values:
 * '123px' 'John', {}, []
 */

////////////////////////////////////////////////////////////
//                       Validator                        //
////////////////////////////////////////////////////////////

var validator = {
	validateCountParameter: function(count) {
		if (count === 'undefined' || isNaN(Number(count)) || count < 1) {
			throw new Error('The count parameter is missing or not convertible to Number');
		}
	},

	validateSelectorParameter: function(selector) {
		if (selector === 'undefined' || selector === 'null' || typeof selector !== 'string') {
			throw new Error('The selector parameter is missing or not a string.');
		}
	}
};

////////////////////////////////////////////////////////////
//                        Helpers                         //
////////////////////////////////////////////////////////////

if (!String.prototype.repeat) {
	String.prototype.repeat = function(times) {
		var repeatedString;
		if (!times) {
			times = 1;
		}
		repeatedString = "";

		for (var i = 0; i < times; i += 1) {
			repeatedString += String(this);
		}
		return repeatedString;
	};
}

////////////////////////////////////////////////////////////
//                  Solving Function                      //                 
////////////////////////////////////////////////////////////

function solve() {
	if (!String.prototype.repeat) {
		String.prototype.repeat = function(times) {
			var repeatedString;
			if (!times) {
				times = 1;
			}
			repeatedString = "";

			for (var i = 0; i < times; i += 1) {
				repeatedString += String(this);
			}
			return repeatedString;
		};
	}

	return function(selector, count) {
		validator.validateCountParameter(count);
		validator.validateSelectorParameter(selector);

		var rootElement = $(selector).html('<ul class="items-list"></ul>');
		var list = $('.items-list').html('<li class="list-item"></li>'.repeat(count));
		var items = list.find('*');
		items.each(function(index, item) {
			item.className = 'list-item';
			item.innerHTML = 'List item #' + index;
		});
	};
}

module.exports = solve;