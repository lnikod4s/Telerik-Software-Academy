var db = (function () {
	function getAllUsers() {
		var promise = new Promise(function (resolve, reject) {
			$.getJSON('api/users', function (response) {
				resolve(response);
			});
		});
	}

	function loginUser(user) {
		var promise = new Promise(function (resolve, reject) {
			$.ajax({
				url: 'api/auth',
				method: 'PUT',
				data: JSON.stringify(user),
				contentType: 'application/json',
				success: function (response) {
					localStorage.setItem('username', response.username);
					localStorage.setItem('authkey', response.authKey);
					resolve(response);
				}
			});
		});

		return promise;
	}

	function registerUser(user) {
		var promise = new Promise(function (resolve, reject) {
			$.ajax({
				url: 'api/users',
				method: 'POST',
				data: JSON.stringify(user),
				contentType: 'application/json',
				success: function (response) {
					localStorage.setItem('username', response.username);
					localStorage.setItem('authkey', response.authKey);
					resolve(response);
				}
			});
		});

		return promise;
	}

	function logoutCurrentUser() {
		var promise = new Promise(function (resolve, reject) {
			localStorage.clear();
			resolve();
		});

		return promise;
	}

	function getAllThreads() {
		var promise = new Promise(function (resolve, reject) {
			$.getJSON('api/threads', function (response) {
				resolve(response);
			});
		});

		return promise;
	}

	function addNewThread(title) {
		var promise = new Promise(function (resolve, reject) {
			$.ajax({
				url: 'api/threads',
				method: 'POST',
				data: JSON.stringify({ title: title }),
				contentType: 'application/json',
				headers: {
					'x-authKey': localStorage.getItem('authkey')
				},
				success: function (response) {
					resolve(response);
				}
			});
		});

		return promise;
	}

	return {
		users: {
			getAllUsers: getAllUsers,
			login: loginUser,
			register: registerUser,
			logout: logoutCurrentUser
		},
		threads: {
			getAllThreads: getAllThreads,
			add: addNewThread
		}
	};
})();