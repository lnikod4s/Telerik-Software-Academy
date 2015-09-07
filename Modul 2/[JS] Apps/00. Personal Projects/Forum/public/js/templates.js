var templates = (function () {
	function get(templateName) {
		var promise = new Promise(function (resolve, reject) {
			var url = '/templates/' + templateName + '.handlebars';
			$.get(url, function (templateData) {
				var compiled = Handlebars.compile(templateData);
				resolve(compiled);
			});
		});

		return promise;
	}

	return { get: get };
})();