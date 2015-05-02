function solveTask() {
	function extractValidEmails(text) {
		var pattern = /(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))/g;
		var validEmails = text.match(pattern);

		return validEmails;
	}

	var text = '(+001 222 222 222), example@gmail.com, test.user@yahoo.co.uk, test@test, @gmail.com, a@a.b, valid@email.com, "just message" <rfernsdfson@gmal.com>, <admin@truformdftechnoproducts.com>, <manager@ysahoo.in>';

	var validEmails = extractValidEmails(text);

	for (var email in validEmails) {
		console.log(validEmails[email])
	}
}

solveTask();