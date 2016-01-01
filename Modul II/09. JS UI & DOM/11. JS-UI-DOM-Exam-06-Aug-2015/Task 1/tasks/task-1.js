function solve() {
	return function(selector, isCaseSensitive) {
		isCaseSensitive = isCaseSensitive || false;
		var itemsControl = document.querySelector(selector);
		itemsControl.className = 'items-control';

		var listItem = document.createElement('div');
		listItem.className = 'list-item';
		var listItemButton = document.createElement('div');
		listItemButton.className = 'button';
		listItemButton.innerHTML = 'X';
		listItem.appendChild(listItemButton);

		// Adding elements
		var addControls = document.createElement('div');
		addControls.className = 'add-controls';
		addControls.innerHTML = 'Enter text';
		addControls.style.height = '60px';

		var addControlsInput = document.createElement('input');
		var addControlsButton = document.createElement('button');
		addControlsButton.className = 'button';
		addControlsButton.innerHTML = 'Add';

		addControls.appendChild(addControlsInput);
		addControls.appendChild(addControlsButton);

		// Searching elements
		var searchControls = document.createElement('div');
		searchControls.className = 'search-controls';
		searchControls.innerHTML = 'Search:';
		searchControls.style.height = '60px';

		var searchControlsInput = document.createElement('input');
		searchControls.appendChild(searchControlsInput);

		// Result elements
		var resultsControl = document.createElement('div');
		resultsControl.className = 'result-controls';

		var resultsControlItemsList = document.createElement('div');
		resultsControlItemsList.className = 'items-list';
		resultsControl.appendChild(resultsControlItemsList);

		itemsControl.appendChild(addControls);
		itemsControl.appendChild(searchControls);
		itemsControl.appendChild(resultsControl);

		addControls.addEventListener('click', function(ev) {
			var clickedElement = ev.target;
			if (clickedElement.parentNode.hasClass('add-controls') && clickedElement.hasClass('button')) {
				var listItemToAdd = listItem.cloneNode(true);
				listItemToAdd.innerHTML = clickedElement.previousElementSibling.value;
				listItemToAdd.className = 'items-list';
				resultsControlItemsList.appendChild(listItemToAdd);
			}
		}, false);

		searchControls.addEventListener('keydown', function(ev) {
			var onKeyUpElement = ev.target;
			if (onKeyUpElement.tagName === 'INPUT') {
				var inputValue = onKeyUpElement.value;
				var listItems = document.getElementsByClassName('list-item');
				for (var item in listItems) {
					if (listItems.hasOwnProperty(item)) {
						if (isCaseSensitive) {
							if (item.innerHTML.indexOf(inputValue) === -1) {
								item.style.display = 'none';
							}
						} else {
							if (item.innerHTML.toLowerCase().indexOf(inputValue.toLowerCase()) === -1) {
								item.style.display = 'none';
							}
						}
					}
				}
			}
		}, false);
	};
}

module.exports = solve;