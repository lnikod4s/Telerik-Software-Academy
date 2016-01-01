var templates = (function () {
	function get(templateName) {
		var promise = new Promise(function (resolve, reject) {
			var url = 'templates/' + templateName + '.handlebars';
			$.get(url, function (html) {
				var template = Handlebars.compile(html);
				resolve(template);
			}).error(function (error) {
				reject(error);
			});
		});

		return promise;
	}

	return { get: get };
})();