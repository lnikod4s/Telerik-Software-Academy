define(['text!templates/login.html'], function (loginTemplate) {
	var loginView = Backbone.View.extend({
		$el: $('#content'),

		$error: $('#error'),

		events: {
			"submit form": "login"
		},

		login: function () {
			$.post('/login', {
				email: $('input[name=email]').val(),
				password: $('input[name=password]').val()
			}, function (data) {
				console.log(data);
			}).error(function () {
				this.$error.text('Unable to login.');
				this.$error.slideDown();
			});

			return false;
		},
		
		render: function () {
			this.$el.html(loginTemplate);
			this.$error.hide();
		}
	});

	return loginView;
});