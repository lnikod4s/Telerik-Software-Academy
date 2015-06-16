var models = models || {};

(function(scope) {
	function ShoppingCart(item) {
		this._items = [];
	}

	ShoppingCart.prototype.addItem = function(item) {
		this._items.push(item);
	};

	scope.getShoppingCart = function(item) {
		return new ShoppingCart(item);
	};
}(models));