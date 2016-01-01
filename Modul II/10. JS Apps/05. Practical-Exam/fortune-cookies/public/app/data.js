var data = (function () {
	/* ======= Users ======= */
	function loginUser(user) {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/auth',
				reqUser = {
					username: user.username,
					passHash: CryptoJS.SHA1(user.password).toString()
				};

			$.ajax({
				url: url,
				method: 'PUT',
				contentType: 'application/json',
				data: JSON.stringify(reqUser),
				success: function (response) {
					localStorage.setItem('key', response.result.authKey);
					resolve(response);
				},
				error: function (error) {
					reject(error);
				}
			});
		});

		return promise;
	}

	function registerUser(user) {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/users',
				reqUser = {
					username: user.username,
					passHash: CryptoJS.SHA1(user.password).toString()
				};

			$.ajax({
				url: url,
				method: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(reqUser),
				success: function (response) {
					resolve(response);
				},
				error: function (error) {
					reject(error);
				}
			});
		});

		return promise;
	}

	function logoutUser(user) {
		var promise = new Promise(function (resolve, reject) {
			localStorage.clear();
			resolve();
		});

		return promise;
	}

	/* ======= Fortune Cookies ======= */
	function getFortuneCookies() {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/cookies';
			$.get(url, function (response) {
				resolve(response);
			});
		});

		return promise;
	}

	function shareFortuneCookie(text, category, img) {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/cookies';
			$.ajax({
				url: url,
				method: 'POST',
				contentType: 'application/json',
				data: JSON.stringify({
					text: text,
					category: category,
					img: img
				}),
				headers: {
					'x-auth-key': localStorage.getItem('key')
				},
				success: function (response) {
					resolve(response);
				},
				error: function (error) {
					reject(error);
				}
			});
		});

		return promise;
	}

	function likesOrDislikesCookie(type) {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/cookies';
			$.ajax({
				url: url,
				method: 'PUT',
				contentType: 'application/json',
				data: JSON.stringify({ type: type }),
				headers: {
					'x-auth-key': localStorage.getItem('key')
				},
				success: function (response) {
					resolve(response);
				},
				error: function (error) {
					reject(error);
				}
			});
		});

		return promise;
	}

	/* ======= My Fortune Cookies ======= */
	function getMyFortuneCookies() {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/my-cookie';
			$.get(url, function (response) {
				resolve(response);
			});
		});

		return promise;
	}

	/* ======= Categories ======= */
	function getCategories() {
		var promise = new Promise(function (resolve, reject) {
			var url = 'api/categories';
			$.get(url, function (response) {
				resolve(response);
			});
		});

		return promise;
	}

	return {
		users: {
			register: registerUser,
			login: loginUser,
			logout: logoutUser
		},
		fortuneCookies: {
			get: getFortuneCookies,
			share: shareFortuneCookie,
			likes: likesOrDislikesCookie
		},
		myFortuneCookies: {
			get: getMyFortuneCookies
		},
		categories: {
			get: getCategories
		}
	};
})();