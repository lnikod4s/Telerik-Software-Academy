var myCookiesController = (function () {
	function all(context) {
		templates.get('my-cookies')
			.then(function (template) {
				context.$element().html(template());
			});
	}

	return { all: all };
})();