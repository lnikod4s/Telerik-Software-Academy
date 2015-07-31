function solve() {
	return function() {
		$.fn.listview = function(data) {
			var compiled = {};
			var id = this.prop('data-value');
			var template = $(id).html();

			compiled[template] = Handlebars.compile(template);
			this.append(compiled[template](data));
		};
	};
}

module.exports = solve;