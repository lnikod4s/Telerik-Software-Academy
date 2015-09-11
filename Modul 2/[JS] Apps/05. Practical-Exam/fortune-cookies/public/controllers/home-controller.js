var homeController = (function () {
	function all(context) {
		var sharedCookies;
		data.fortuneCookies.get()
			.then(function (response) {
				sharedCookies = response.result;
				return templates.get('home');
			})
			.then(function (template) {
				context.$element().html(template(sharedCookies));
			});
	}

	return {
		all: all
	};
})();