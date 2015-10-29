/*#DOM Operations
 _For instructions on how to run the tests, check the following link:
 https://github.com/TelerikAcademy/JavaScript-UI-and-DOM/blob/master/README.md#user-content-preparing-the-local-machine-for-unit-testing-with-mocha-and-chai_

 ##Task 1
 Create a dropdown list by a given select
 * For clearance, check the example and the unit tests

 * _Example:_
 * By given the HTML:



 <select id="the-select">
 <option value="value-1">Option 1</option>
 <option value="value-2">Option 2</option>
 <option value="value-3">Option 3</option>
 <option value="value-4">Option 4</option>
 <option value="value-5">Option 5</option>
 </select>

 * And JavaScript:



 dropdownList('#the-select');

 * Generate the following and attaches the events:



 <div class="dropdown-list">
 <select style="display: none;">
 <option value="value-1">Option 1</option>
 <option value="value-2">Option 2</option>
 <option value="value-3">Option 3</option>
 <option value="value-4">Option 4</option>
 <option value="value-5">Option 5</option>
 </select>
 <div class="current" data-value="">Option 1</div>
 <div class="options-container" style="position: absolute; display: none;">
 <div class="dropdown-item" data-value="value-1" data-index="0">Option1</div>
 <div class="dropdown-item" data-value="value-2" data-index="1">Option 2</div>
 <div class="dropdown-item" data-value="value-3" data-index="2">Option 3</div>
 <div class="dropdown-item" data-value="value-4" data-index="3">Option 4</div>
 <div class="dropdown-item" data-value="value-5" data-index="4">Option 5</div>
 </div>
 </div>
 */

////////////////////////////////////////////////////////////
//                   Solving Function                     //
////////////////////////////////////////////////////////////

function solve() {
	return function(selector) {
		$(selector)
			.wrap('<div class="dropdown-list"></div>') // Wraps the selected element in a div with class="dropdown-list"
			.css('display', 'none') // Hides the selected element
			.children() // Gets all children
			.each(function(index, item) {
				      $(item).addClass('dropdown-item'); // Adds a class="dropdown-item" to each child
			      });

		// Appends a new div to the wrapper with class="dropdown-list"
		$('.dropdown-list').append('<div class="current"></div>');

		// Adds an onclick functionality to the div with class="current"
		$('.current').on('click', function() {
			$(selector).css('display', 'block');
			$(this).attr('data-value', $(selector).val());
		});
	};
}

module.exports = solve;