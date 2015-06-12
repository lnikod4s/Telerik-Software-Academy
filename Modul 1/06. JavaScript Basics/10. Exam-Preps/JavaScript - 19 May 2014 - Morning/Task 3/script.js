function solve(args) {
	var modelsCount = Number(args[0]);

	var models = parseModels();
	var output = parseShaver();

	function parseModels() {
		var models = {};

		for (var i = 1; i <= modelsCount; i += 1) {
			var line = args[i].split(':');
			var key = line[0];
			var value = line[1];

			if (value.indexOf(',') > -1) {
				value = value.split(',').map(function (item) {
					if (isNumber(item)) {
						item = Number(item);
					}

					return item;
				});
			} else if (value === 'true' || value === 'false') {
				value = value === 'true';
			}

			models[key] = value;
		}

		return models;
	}

	function parseShaver() {
		var output = args.slice(modelsCount + 2).join('\n');

		// -------------------------- EXTRACT SECTIONS --------------------------
		var sections = {};
		output = output.replace(/(?:@section (\w+) \{\n([^]+?)\n}\n)/g, function (match, name, content) {
			sections[name] = content;
			return '';
		});

		// -------------------------- MASK ESCAPING --------------------------
		output = output.replace(/@@/g, '@@$');

		// -------------------------- RENDER MODELS --------------------------
		output = output.replace(/@(\w+)/g, function (match, name) {
			if (models[name]) {
				return models[name];
			} else {
				return match;
			}
		});

		if (Object.keys(sections).length !== 0) {
			// -------------------------- RENDER SECTIONS --------------------------
			output = output.replace(/(?:( *?)@renderSection\("(\w+)"\))/g, function (match, indent, name) {
				return sections[name].replace(/^/gm, indent);
			});
		}

		// -------------------------- RENDER CONDITIONAL STATEMENTS --------------------------
		output = output.replace(/(?:( *?)@if \((\w+)\) {\n([^]+?)\n +?}\n)/g, function (match, indent, condition, content) {
			if (models[condition]) {
				return content.replace(/^ {4}/gm, '').replace(/$/g, '\n');
			} else {
				return '';
			}
		});

		// -------------------------- RENDER LOOPS --------------------------
		output = output.replace(/(?: *@foreach \(var (\w+) in (\w+)\) {\n([^]+?)}\n)/g,
			function (match, iterator, name, content) {
				var output = '';
				content = content.replace(/\s*$/, '\n');
				for (var i = 0; i < models[name].length; i += 1) {
					output += content
						.replace(new RegExp('@' + iterator, 'g'), models[name][i])
						.replace(/^ {4}/gm, '');
				}

				return output;
			});

		// -------------------------- UNMASK ESCAPING --------------------------
		output = output.replace(/@@\$/g, '@').replace(/@@/g, '@');

		return output;
	}

	function isNumber(n) {
		return !isNaN(parseFloat(n)) && isFinite(n);
	}

	return output;
}

console.log(solve([
	'15',
	'text:RandomText',
	'anotherText:RandomTextAgain',
	'passTheIf:true',
	'doNotPassTheIf:false',
	'passTheIf:true',
	'doNotPassTheIf:false',
	'pesho:na peshlqka modela',
	'gosho:i gosho e tuka brato',
	'someNumbers:1,2,3,4,5',
	'someTechs:asp.net,mvc,angular,node,c-sharp',
	'someNumbersHere:1,2,3,4,5',
	'someTechsHere:asp.net,mvc,angular,node,c-sharp',
	'kolio:nikolay',
	'minkov:donchoviq',
	'unused:just unused model',
	'106',
	'@section first {',
	'	<ul>',
	'		<li>',
	'			In section UL',
	'		</li>',
	'		<li>',
	'			Still in section UL',
	'		</li>',
	'	</ul>',
	'}',
	'@section second {',
	'	<div>',
	'		Second section :)',
	'	</div>',
	'}',
	'<div>',
	'	<p>',
	'		@@if (pesho) {',
	'		@@escaped dude',
	'		}',
	'	</p>',
	'	<p>',
	'		@@renderSection("pesho")',
	'	</p>',
	'	<p>',
	'		@@foreach(var pesho in peshos) {',
	'		@@escaped in comment',
	'		}',
	'	</p>',
	'</div>',
	'<div>',
	'@renderSection("first")',
	'@renderSection("second")',
	'</div>',
	'<div>',
	'	<div>',
	'		@text',
	'	</div>',
	'	<ul>',
	'		<li>',
	'			<span>@anotherText</span>',
	'		</li>',
	'	</ul>',
	'</div>',
	'<div>',
	'<p>Some bulsh*t text</p>',
	'<br />',
	'@if (passTheIf) {',
	'	<span>Passed</span>',
	'}',
	'<br />',
	'<div>',
	'<span>More bulsh*t text</span>',
	'@if (doNotPassTheIf) {',
	'	<span>if this passes this is error</span>',
	'}',
	'<div>',
	'</div>',
	'<div>',
	'<p>Some bulsh*t text + @pesho & @gosho</p>',
	'<br />',
	'@if (passTheIf) {',
	'	<span>Passed @pesho and @gosho</span>',
	'}',
	'<br />',
	'<div>',
	'<span>More bulsh*t text</span>',
	'@if (doNotPassTheIf) {',
	'	<span>if this passes this is error @pesho and @gosho</span>',
	'}',
	'<div>',
	'</div>',
	'<div>',
	'<span>Some bulsh*t text</span>',
	'<br />',
	'@foreach (var number in someNumbers) {',
	'	<span>@number da ima</span>',
	'	<span>only @number</span>',
	'}',
	'<br />',
	'<div>',
	'<span>More bulsh*t text</span>',
	'@foreach (var tech in someTechs) {',
	'	<span>@tech is cool</span>',
	'	<span>and @tech is mama</span>',
	'}',
	'<div>',
	'</div>',
	'<div>',
	'<span>Some bulsh*t text</span>',
	'<br />',
	'@foreach (var someNumber in someNumbersHere) {',
	'	<span>@someNumber da ima</span>',
	'	<span>only @someNumber</span>',
	'	<strong>@kolio</strong>',
	'}',
	'<br />',
	'<div>',
	'<span>More bulsh*t text</span>',
	'@foreach (var someTech in someTechsHere) {',
	'	<span>@someTech is cool</span>',
	'	<span>and @someTech is mama</span>',
	'	<strong>@minkov</strong>',
	'}',
	'<div>',
	'</div>'
]));