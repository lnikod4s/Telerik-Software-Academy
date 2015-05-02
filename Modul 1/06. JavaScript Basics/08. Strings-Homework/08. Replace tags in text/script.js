function solveTask() {
	function replaceTags(text) {
		var pattern = /<a href="(.*?)">(.*?)<\/a>/gi;

		return text.replace(pattern, function (tag, url, message) {
			return "[URL=" + url + ']' + message + '[\/URL]';
		});
	}

	var html = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
	var escapedHtml = replaceTags(html);

	console.log(html);
	console.log(escapedHtml);
}

solveTask();