(function () {
	var app = Sammy('#content', function () {
		this.get('#/', function () {
			this.redirect('#/home');
		});

		this.get('#/home', homeController.all);

		this.get('#/register', usersController.register);

		this.get('#/cookies', cookiesControler.all);
		this.get('#/cookies/share', cookiesControler.share);

		this.get('#/categories', categoriesController.all);

		this.get('#/my-cookie', myCookiesController.all);
	});

	(function () {
		app.run('#/');
	})();
})();