function solve() {
	$.fn.datepicker = function() {
		////////////////////////////////////////////////////////////
		//                       Helpers                          //
		////////////////////////////////////////////////////////////
		Date.prototype.getMonthName = function() {
			return MONTH_NAMES[this.getMonth()];
		};

		Date.prototype.getDayName = function() {
			return WEEK_DAY_NAMES[this.getDay()];
		};
		var date = new Date();
		var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
		var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

		var $datepicker = $(this);
		$datepicker.wrap('<div class="datepicker-wrapper"></div>');
		$datepicker.addClass('datepicker');
		var $wrapper = $datepicker.parent();

		$wrapper.on('click', '.datepicker', function() {
			$calendar.show();
		});

		var $calendar = $('<div \>')
			.addClass('picker')
			.appendTo($wrapper);

		var $header = $('<header \>')
			.addClass('controls')
			.css('text-align', 'center')
			.appendTo($calendar);
		$header
			.css('width', '96%')
			.css('height', '10%');

		var $leftButton = $('<span \>');
		$leftButton
			.text('<')
			.css('float', 'left')
			.addClass('btn');
		$leftButton.appendTo($header);

		var $headerText = $('<span \>');
		$headerText.text(date.getMonthName() + ' ' + date.getFullYear());
		$headerText.appendTo($header);

		var $rightButton = $('<span \>');
		$rightButton
			.text('>')
			.css('float', 'right')
			.addClass('btn');
		$rightButton.appendTo($header);

		var $mainContent = $('<div />').appendTo($calendar);
		$mainContent
			.css('width', '96%')
			.css('height', '74%');

		var $footer = $('<footer \>')
			.addClass('controls')
			.appendTo($calendar);
		$footer
			.css('width', '96%')
			.css('height', '10%')
			.css('text-align', 'center');

		var $footerSpan = $('<span \>');
		$footerSpan.text(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear());
		$footerSpan.appendTo($footer);
	};
}

module.exports = solve;