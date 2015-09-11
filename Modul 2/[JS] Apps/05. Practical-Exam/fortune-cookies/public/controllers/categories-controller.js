var categoriesController = (function () {
	function all(context) {
		var categories;
		data.categories.get()
			.then(function (response) {
				categories = response.result;
				return templates.get('categories');
			})
			.then(function (template) {
				context.$element().html(template(categories));
			});
	}

	return { all: all };
})();