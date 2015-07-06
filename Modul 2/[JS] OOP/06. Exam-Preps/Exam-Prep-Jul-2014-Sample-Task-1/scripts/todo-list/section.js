define(function() {
	'use strict';
	var Section;
	Section = (function() {
		function Section(title) {
			this._title = title;
			this._items = [];
		}

		Section.prototype = {
			add: function(item) {
				this._items.push(item);

				return this;
			},
			getData: function() {
				var items = [];
				this._items.forEach(function(item) {
					items.push(item.getData());
				});

				return {
					title: this._title,
					items: items
				}
			}
		};

		return Section;
	}());
	return Section;
});