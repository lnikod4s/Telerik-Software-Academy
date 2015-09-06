var templates = (function () {
	function get(templateName) {
		var url = '/templates/' + templateName + '.handlebars';
		var promise = new Promise(function (resolve, reject) {
			$.get(url, function (templateHtml) {
				var template = Handlebars.compile(templateHtml);
				resolve(template);
			});
		});

		return promise;
	}

	return { get: get };
})();