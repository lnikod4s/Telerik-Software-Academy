var data = (function () {
	function getUserById(id) {
		var promise = new Promise(function (resolve, reject) {
			var resultArr = $.getJSON('api/users').result;
			var searchedItem = resultArr.find(function (item, index) {
				return item.id === id;
			});

			resolve(searchedItem);
		});

		return promise;
	}

	function getAllUsers() {
		var promise = new Promise(function (resolve, reject) {
			$.getJSON('api/users', function (response) {
				resolve(response);
			});
		});

		return promise;
	}

	function loginUser(user) {
		var promise = new Promise(function (resolve, reject) {
			$.ajax({
				url: 'api/auth',
				method: 'PUT',
				data: JSON.stringify(user),
				contentType: 'application/json',
				success: function (response) {
					localStorage.setItem('user', response.username);
					localStorage.setItem('key', response.authKey);
					resolve(response);
				}
			});
		});

		return promise;
	}

	function logoutUser() {
		var promise = new Promise(function (resolve, reject) {
			localStorage.removeItem('user');
			localStorage.removeItem('key');
			resolve();
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
					localStorage.setItem('user', response.username);
					localStorage.setItem('key', response.authKey);
					resolve(response);
				}
			});
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
					'x-authkey': localStorage.getItem('key')
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
			getUserById: getUserById,
			getAllUsers: getAllUsers,
			login: loginUser,
			logout: logoutUser,
			register: registerUser
		},
		threads: {
			getAllThreads: getAllThreads,
			add: addNewThread
		}
	};
})();