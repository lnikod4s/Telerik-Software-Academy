function solveTask() {
	function extractURLElements(url) {
		var pattern = /(.*):\/\/(.*?)(\/.*)/g;

		return pattern.exec(url);
	}

	var urlAddress = "https://www.devbg.org/forum/index.php";

	var fragments = extractURLElements(urlAddress);

	// Convert to JSON object
	var jsonObject = JSON.stringify({
		protocol: fragments[1],
		server: fragments[2],
		resource: fragments[3]
	});

	console.log("JSON: " + jsonObject);

	// Parse JSON object to JS object
	var jsObject = JSON.parse(jsonObject);

	console.log("URL Address: " + urlAddress);
	console.log("[protocol] = " + jsObject.protocol);
	console.log("[server] = " + jsObject.server);
	console.log("[resource] = " + jsObject.resource);
}

solveTask();