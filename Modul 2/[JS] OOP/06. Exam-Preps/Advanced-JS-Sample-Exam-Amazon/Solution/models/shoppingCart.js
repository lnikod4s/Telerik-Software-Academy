var models = models || {};
(function (scope) {
	function ShoppingCart() {
		this._items = [];
	}

	ShoppingCart.prototype.addItem = function addItem(item) {
		this._items.push(item);
	}

	ShoppingCart.prototype.getTotalPrice = function () {
		var totalPrice = 0;

		this.items.forEach(function (item) {
		 	totalPrice += item.price;
		});

		return totalPrice;
	}

	scope._ShoppingCart = ShoppingCart;

	scope.getShoppingCart = function getShoppingCart() {
		return new ShoppingCart();
	};
}(models));