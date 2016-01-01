var app = Sammy('#content', function () {
	var $content = $('#content');

	this.get('#/', function () {
		var threads;
		db.threads.getAllThreads()
			.then(function (response) {
				threads = response.result;
				return templates.get('home');
			})
			.then(function (template) {
				$content.html(template(threads));
			});
	});

	this.get('#/login', function (context) {
		templates.get('home')
			.then(function (template) {
				$content.html(template());

				$('#btn-login').on('click', function () {
					$('.input-group').hide();
					$('#btn-login').hide();
					$('#btn-register').hide();
					$('#btn-logout').show();

					var user = {
						username: $('#username').val(),
						passHash: $('#password').val()
					};

					db.users.login(user)
						.then(function (response) {
							context.redirect('#/');
						});
				});

				$('#btn-register').on('click', function () {
					var user = {
						username: $('#username').val(),
						passHash: $('#password').val()
					};

					db.users.register(user)
						.then(function (response) {
							context.redirect('#/login');
							document.location.reload(true);
						});
				});
			});
	});

	this.get('#/logout', function (context) {
		context.redirect('#/login');
		document.location.reload(true);
	});

	this.get('#/threads', function (context) {
		context.redirect('#/');
	});

	this.get('#/threads/add', function (context) {
		templates.get('add-thread')
			.then(function (template) {
				$content.html(template());

				$('#btn-add-thread').on('click', function () {
					var title = $('#it-thread-title').val();
					db.threads.add(title)
						.then(function () {
							context.redirect('#/threads');
						});
				});
			});
	});
});

app.run('#/');