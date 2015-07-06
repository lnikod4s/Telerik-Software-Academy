var amazon = amazon || {};

(function (amazon) {
	var fragment = new DocumentFragment();
	var _categories = [];

	function loadHtml(categories) {
		var ul = loadCategories(categories);
		document.getElementById('categories').appendChild(ul);
		ul.addEventListener('click', function (ev) {
			var category = _categories.filter(function (category) {
				return category.name == ev.target.getAttribute('data-name');
			})[0];

			loadItems(category.getItems());
		});
	}

	function loadUsers(users) {
		var usersDiv = document.getElementById('users');
		var ul = document.createElement('ul');
		users.forEach(function (user) {
			var userLi = document.createElement('li');
			userLi.innerHTML = '<div>' + user.username + '</div>';
			userLi.innerHTML += '<div>' + user.fullName + '</div>';
			userLi.innerHTML += '<div>' + user._balance + '</div>';
			ul.appendChild(userLi);
		});
		
		usersDiv.appendChild(ul);
	}

	function loadCategories (categories) {
		var ulCategories = document.createElement('ul');
		categories.forEach(function (category) {
			_categories.push(category);
			var liCategory = document.createElement('li');
			liCategory.innerHTML = category.name;
			liCategory.setAttribute('data-name', category.name);
			ulCategories.appendChild(liCategory);
			if (category._categories.length > 0) {
				var nestedCategories = loadCategories(category._categories);
				liCategory.appendChild(nestedCategories);
			};
		});

		return ulCategories;
	}

	function loadItems(items) {
		var itemsDiv = document.getElementById('items');
		if (!items.length) {
			itemsDiv.innerHTML = 'The category is empty!';
			return;
		};

		var ulItems = document.createElement('ul');
		items.forEach(function (item) {
			var liItem = document.createElement('li');
			liItem.innerHTML = '<div>' + item.title + '</div>';
			liItem.innerHTML += '<div>' + item.description + '</div>';
			liItem.innerHTML += '<div>' + item.price + '</div>';

			ulItems.appendChild(liItem);
		});

		itemsDiv.innerHTML = '';
		itemsDiv.appendChild(ulItems);
	}

	amazon.loadHtml = loadHtml;
	amazon.loadUsers = loadUsers;
}(amazon));