function solve(args) {
	var N = Number(args[0]), M = Number(args[N + 1]);
	var models = {}, output = '';
	var currLine;

	for (var i = 1; i <= N; i++) {
		currLine = args[i];
		var splittedLine = currLine.split(':');
		models[splittedLine[0]] = splittedLine[1].indexOf(',') === -1
			? splittedLine[1]
			: splittedLine[1].split(',').map(function (item) {
			return !isNaN(item)
				? parseInt(item)
				: item;
		})
	}

	for (var j = 0; j < M; j++) {
		currLine = args[j + N + 2];

		output += currLine + '\n';
	}

	return output;
}

console.log(solve([
	'6',
	'title:Telerik Academy',
	'showSubtitle:true',
	'subTitle:Free training',
	'showMarks:false',
	'marks:3,4,5,6',
	'students:Pesho,Gosho,Ivan',
	'42',
	'@section menu {',
	'<ul id="menu">',
	'    <li>Home</li>',
	'    <li>About us</li>',
	'</ul>',
	'}',
	'@section footer {',
	'<footer>',
	'    Copyright Telerik Academy 2014',
	'</footer>',
	'}',
	'<!DOCTYPE html>',
	'<html>',
	'<head>',
	'    <title>Telerik Academy</title>',
	'</head>',
	'<body>',
	'    @renderSection("menu")',
	'',
	'    <h1>@title</h1>',
	'    @if (showSubtitle) {',
	'        <h2>@subTitle</h2>',
	'        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
	'    }',
	'',
	'    <ul>',
	'        @foreach (var student in students) {',
	'            <li>',
	'                @student ',
	'            </li>',
	'            <li>Multiline @title</li>',
	'        }',
	'    </ul>',
	'    @if (showMarks) {',
	'        <div>',
	'            @marks',
	'        </div>',
	'    }',
	'',
	'    @renderSection("footer")',
	'</body>',
	'</html>'
]));