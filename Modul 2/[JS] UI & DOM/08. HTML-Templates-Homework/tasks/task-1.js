function solve() {
	return function(selector) {
		var template = '<table class="items-table">' +
		               '<thead>' + // opening thead
		               '<tr>' +
		               '<th>' +
		               '#' +
		               '</th>' +
		               '{{#each headers}}' +
		               '<th>' +
		               '{{this}}' +
		               '</th>' +
		               '{{/each}}' +
		               '</tr>' +
		               '</thead>' + // closing thead
		               '<tbody>' + // opening tbody
		               '{{#each items}}' +
		               '<tr>' +
		               '<td>' +
		               '{{@index}}' +
		               '</td>' +
		               '<td>' +
		               '{{col1}}' +
		               '</td>' +
		               '<td>' +
		               '{{col2}}' +
		               '</td>' +
		               '<td>' +
		               '{{col3}}' +
		               '</td>' +
		               '</tr>' +
		               '{{/each}}' +
		               '</tbody>' + // closing tbody
		               '</table>';

		$(selector).html(template);
	};
}

module.exports = solve;