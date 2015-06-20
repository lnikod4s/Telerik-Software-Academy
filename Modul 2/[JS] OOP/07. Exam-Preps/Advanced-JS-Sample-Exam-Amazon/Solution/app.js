(function (amazon) {
	amazon.generateData();
	var categories = amazon.getCategories();
	var users = amazon.getUsers();

	amazon.loadHtml(categories);
	amazon.loadUsers(users);

	console.log(categories);
	console.log(users);
}(amazon));