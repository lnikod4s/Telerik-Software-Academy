/* global sha1 */
var app = Sammy('#content', function () {
	var $content = $('#content');

	this.get('#/', function (context) {

	});

	this.get('#/login', function (context) {
		templates.get('home')
			.then(function (template) {
				$content.html(template());

				$('#btn-login').on('click', function () {
					var user = {
						username: $('#username').val(),
						passHash: $('#password').val()
					};

					var cryptedUser = {
						username: user.username,
						passHash: sha1(user.passHash)
					};

					data.users.login(cryptedUser)
						.then(function () {
							$('.input-group').hide();
							$('#btn-login').hide();
							$('#btn-register').hide();
							$('#btn-logout').fadeIn(500);
							context.redirect('#/threads');
						});
				});

				$('#btn-register').on('click', function () {
					var user = {
						username: $('#username').val(),
						passHash: $('#password').val()
					};

					var cryptedUser = {
						username: user.username,
						passHash: sha1(user.passHash)
					};

					data.users.register(cryptedUser)
						.then(function () {
							context.redirect('#/');
						});
				});
			});
	});

	this.get('#/logout', function (context) {
		data.users.logout()
			.then(function () {
				context.redirect('#/');
				document.location.reload(true);
			});
	});

	this.get('#/threads', function () {
		var threads;
        data.threads.getAllThreads()
			.then(function (response) {
				threads = response.result;
				return templates.get('threads');
			})
			.then(function (template) {
				$content.html(template(threads));
			});
	});

	this.get('#/threads/add', function (context) {
		templates.get('add-thread')
			.then(function (template) {
				$content.html(template());

				$('#btn-add-thread').on('click', function () {
					var title = $('#it-thread-title').val();
					data.threads.add(title)
						.then(function () {
							context.redirect('#/threads');
						});
				});
			});
	});
});

app.run('#/');