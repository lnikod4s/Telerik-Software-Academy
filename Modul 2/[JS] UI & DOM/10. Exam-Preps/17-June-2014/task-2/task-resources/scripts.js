/* globals $ */
$.fn.gallery = function() {
	var cols = arguments[0] || 4;
	var $this = $(this).addClass('gallery');
	$this.find('.selected').hide();
	var $imagesCount = $this.find('.image-container').length;
	var $selectedImages = $this.find('.selected');
	var $galleryList = $this.find('.gallery-list');
	var singleImageWidth = $this.find('.image-container').outerWidth(true);
	$this.width(singleImageWidth * cols);

	$this.on('click', $('.image-container img'), function(ev) {
		var target = ev.target;
		var currIndex = +target.dataset.info;
		var nextIndex = currIndex == $imagesCount ? 1 : currIndex + 1;
		var prevIndex = currIndex == 1 ? $imagesCount : currIndex - 1;

		var $currClickedImg = $('img[data-info=' + currIndex + ']');
		var $prevClickedImg = $('img[data-info=' + prevIndex + ']');
		var $nextClickedImg = $('img[data-info=' + nextIndex + ']');

		$galleryList.addClass('blurred');
		$this.addClass('disabled-background');

		$selectedImages.show();
		var $currSelectedImg = $selectedImages.find('#current-image');
		$.each($currClickedImg.prop('attributes'), function() {
			$currSelectedImg.attr(this.name, this.value);
		});
		var $prevSelectedImg = $selectedImages.find('#previous-image');
		$.each($prevClickedImg.prop('attributes'), function() {
			$prevSelectedImg.attr(this.name, this.value);
		});
		var $nextSelectedImg = $selectedImages.find('#next-image');
		$.each($nextClickedImg.prop('attributes'), function() {
			$nextSelectedImg.attr(this.name, this.value);
		});
	});
};