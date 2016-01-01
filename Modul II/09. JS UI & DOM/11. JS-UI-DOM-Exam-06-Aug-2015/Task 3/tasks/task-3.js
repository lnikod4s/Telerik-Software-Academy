function solve() {
	return function(selector) {
		var template = '<div class="events-calendar">' +
		               '<h2 class="header">' +
		               'Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>' +
		               '</h2>' +
		               '{{#each days}}' +
		               '<div class="col-date">' +
		               '<div class="date">{{day}}</div>' +
		               '{{#each events}}' +
		               '<div class="event {{importance}}"{{#if comment}} title="{{comment}}"{{/if}}>' +
		               '{{#if title}}' +
		               '<div class="title">{{title}}</div>' +
		               '{{else}}' +
		               '<div class="title">Free slot</div>' +
		               '{{/if}}' +
		               '</div>' +
		               '{{/each}}' +
		               '</div>' +
		               '{{/each}}' +
		               '</div>';
		document.getElementById(selector).innerHTML = template;
	};
}

module.exports = solve;