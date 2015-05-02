function solveTask() {
	var input = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>;";
	var result = input.replace(/<(.*?)>/g, '');

	console.log(input);
	console.log(result);
}

solveTask();