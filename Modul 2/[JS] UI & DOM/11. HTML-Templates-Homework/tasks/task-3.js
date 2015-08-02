function solve() {
	return function() {
		$.fn.listview = function(data) {
			var $this = $(this);
			var id = '#' + $this.attr('data-template');
			var template = $(id).html();
			var compiledTemplate = handlebars.compile(template);
			data.forEach(function(item) {
				$this.append(compiledTemplate(item));
			});
		};
	};
}

module.exports = solve;