define(function() {
	'use strict';
	var Container;
	Container = (function() {
		function Container() {
			this._container = [];
		}

		Container.prototype = {
			add: function(section) {
				this._container.push(section);

				return this;
			},
			getData: function() {
				var container = [];
				this._container.forEach(function(item) {
					container.push(item.getData());
				});

				return container;
			}
		};

		return Container;
	}());
	return Container;
});