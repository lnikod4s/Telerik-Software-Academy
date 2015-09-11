var cookiesControler = (function () {
	function all(context) {
		data.fortuneCookies.get()
			.then(function () {
				context.redirect('#/');
			});
	}

	function share(context) {
		templates.get('cookies-share')
			.then(function (template) {
				context.$element().html(template());

				/* ======= Attach events ======= */
				$('#btn-cookie-share').on('click', function () {
					var text = $('#tb-cookie-text').val(),
						category = $('#tb-cookie-category').val(),
						imgLink = $('#tb-cookie-img').val();

					data.fortuneCookies.share(text, category, imgLink)
						.then(function (cookie) {
							toastr.success("Awesome! You've just shared a new fortune cookie");
							context.redirect('#/');
						});
				});
			});
	}

	return {
		all: all,
		share: share
	};
})();