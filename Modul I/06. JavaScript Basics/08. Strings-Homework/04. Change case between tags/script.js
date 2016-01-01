function solveTask() {
	String.prototype.escapeTags = function() {
		return this.escapeUpcaseTags().escapeLowcaseTags().escapeMixcaseTags();
	};

	String.prototype.escapeUpcaseTags = function() {
		return this.replace(/<upcase>(.*?)<\/upcase>/gi, function(tag, match) {
			return match.toUpperCase();
		});
	};

	String.prototype.escapeLowcaseTags = function() {
		return this.replace(/<lowcase>(.*?)<\/lowcase>/gi, function(tag, match) {
			return match.toLowerCase();
		});
	};

	String.prototype.escapeMixcaseTags = function() {
		return this.replace(/<mixcase>(.*?)<\/mixcase>/gi, function(tag, match) {
			return match.toMixCase();
		});
	};

	String.prototype.toMixCase = function() {
		var result = "", letter = "", toLowerCase = false;

		for (var i = 0; i < this.length; i++) {
			toLowerCase = Math.round(Math.random()); // Returns 0 or 1
			letter = this.charAt(i);

			result += (toLowerCase ? letter.toUpperCase() : letter.toLowerCase());
		}

		return result;
	};

	var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYTHING</lowcase> else.";
	var escapedText = text.escapeTags();

	console.log(text);
	console.log(escapedText);
}

solveTask();