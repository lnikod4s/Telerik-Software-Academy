var usersController = (function () {
	function all(context) {
		var promise = new Promise(function (resolve, reject) {
			$.getJSON('api/users', function (response) {
				resolve(response);
			});
		});

		return promise;
	}

	function register(context) {
		templates.get('register')
			.then(function (template) {
				context.$element().html(template());
				/* ======= Attach events ======= */
				$('#btn-register').on('click', function () {
					var user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};

					data.users.register(user)
						.then(function () {
							toastr.success('User registered');
						});
				});

				$('#btn-login').on('click', function () {
					var user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};

					data.users.login(user)
						.then(function () {
							$('#btn-login-register').hide();
							$('#btn-logout').show();
							toastr.success('User logged in');
							context.redirect('#/');
						});
				});

				$('#btn-logout').on('click', function () {
					data.users.logout()
						.then(function () {
							$('#btn-login-register').show();
							$('#btn-logout').hide();
							toastr.success('User logged out');
						});
				});
			});
	}

	return {
		all: all,
		register: register
	};
})();