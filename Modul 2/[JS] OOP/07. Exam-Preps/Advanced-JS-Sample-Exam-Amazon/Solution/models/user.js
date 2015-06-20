var models = models || {};

(function (scope) {
	function User(username, fullName, balance) {
		this.username = username;
		this.fullName = fullName;
		this._balance = balance;
		this._shoppingCart = new scope._ShoppingCart();
	}

	User.prototype.addItemToCart = function addItemToCart(item) {
		this._shoppingCart.addItem(item);
	}

	scope.getUser = function getUser(username, fullName, balance) {
		return new User(username, fullName, balance);
	};
}(models));