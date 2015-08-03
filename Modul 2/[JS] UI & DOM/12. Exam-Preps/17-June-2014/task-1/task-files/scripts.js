////////////////////////////////////////////////////////////
//                        Helpers                         //
////////////////////////////////////////////////////////////

Element.prototype.setAttributes = function(attributes) {
	for (var index in attributes) {
		if (attributes.hasOwnProperty(index)) {
			if ((index === 'styles' || index === 'style') && typeof attributes[index] === 'object') {
				for (var prop in attributes[index]) {
					if (attributes[index].hasOwnProperty(prop)) {
						this.style[prop] = attributes[index][prop];
					}
				}
			} else if (index === 'html') {
				this.innerHTML = attributes[index];
			} else {
				this.setAttribute(index, attributes[index]);
			}
		}
	}
};

Element.prototype.applyStyles = function(styles) {
	for (var prop in styles) {
		if (styles.hasOwnProperty(prop)) {
			this.style[prop] = styles[prop];
		}
	}
};

////////////////////////////////////////////////////////////
//                   Solving Function                     //
////////////////////////////////////////////////////////////
function createImagesPreviewer(selector, items) {
	var container = document.querySelector(selector);
	var leftBoxImage, rightBoxListItems, leftBoxTitle;

	var previewer = createPreviewer();
	container.appendChild(previewer);

	function createPreviewer() {
		var previewerBox = createPreviewerBox();
		createLeftBox(previewerBox);
		createRightBox(previewerBox);

		return previewerBox;
	}

	function createPreviewerBox() {
		// .previewer-container
		var previewerBox = document.createElement('div');
		previewerBox.applyStyles({
			width: '560px',
			height: '380px',
			borderRadius: '15px',
			boxShadow: '1px 1px 10px #cacaca',
			className: 'previewer-container'
		});

		return previewerBox;
	}

	function createLeftBox(previewerBox) {
		// .previewer-leftBox
		var leftBox = document.createElement('div');
		leftBox.applyStyles({
			width: '70%',
			height: '100%',
			display: 'inline-block',
			verticalAlign: 'top',
			textAlign: 'center',
			className: 'previewer-leftBox'
		});

		previewerBox.appendChild(leftBox);

		// .previewer-leftBox-title
		leftBoxTitle = document.createElement('h1');
		leftBoxTitle.applyStyles({
			width: '100%',
			marginTop: '7%',
			className: 'previewer-leftBox-title'
		});

		leftBoxTitle.innerText = items[0].title;
		leftBox.appendChild(leftBoxTitle);

		// .previewer-leftBox-image
		leftBoxImage = document.createElement('img');
		leftBoxImage.applyStyles({
			width: '90%',
			borderRadius: '15px',
			border: '1px solid #ddd'
		});

		leftBoxImage.setAttribute('src', items[0].url);
		leftBoxImage.className = 'previewer-leftBox-image'
		leftBox.appendChild(leftBoxImage);
	}

	function createRightBox(previewerBox) {
		// .previewer-rightBox
		var rightBox = document.createElement('div');
		rightBox.applyStyles({
			width: '29%',
			height: '93%',
			marginTop: '2%',
			display: 'inline-block',
			textAlign: 'center',
			overflowY: 'scroll'
		});

		rightBox.className = 'previewer-rightBox';
		previewerBox.appendChild(rightBox);

		// .previewer-rightBox-filter-label
		var filterLabel = document.createElement('label');
		filterLabel.innerHTML = 'Filter';
		filterLabel.className = 'previewer-rightBox-filter-label';
		filterLabel.applyStyles({
			textAlign : 'center',
			display : 'block',
			marginTop : '0px'
		})

		rightBox.appendChild(filterLabel);

		// .previewer-rightBox-filter
		var filter = document.createElement('input');
		filter.type = 'text';
		filter.style.width = '80%';
		addFilterEventHandlers(filter);
		filter.className = 'previewer-rightBox-filter';
		rightBox.appendChild(filter);

		// .previewer-rightBox-list
		var rightBoxList = document.createElement('ul');
		rightBoxList.applyStyles({
			listStyleType  : 'none',
			padding   : '0',
			marginTop : '0'
		});
		rightBoxList.className = 'previewer-rightBox-list';

		// templates
		var liTemplate = document.createElement('li');

		var imgTitleTemplate = document.createElement('h4');
		imgTitleTemplate.style.margin = '0';

		var imgTemplate = document.createElement('img');
		imgTemplate.style.width = '80%';
		imgTemplate.style.borderRadius = '5px';

		var li, img, imgTitle;
		for (var i = 0; i < items.length; i++) {
			// clone nodes
			li = liTemplate.cloneNode(true);
			img = imgTemplate.cloneNode(true);
			imgTitle = imgTitleTemplate.cloneNode(true);

			imgTitle.innerHTML = items[i].title;
			img.src = items[i].url;
			img.title = items[i].title;
			addImageEventHandlers(img);
			li.appendChild(imgTitle);
			li.appendChild(img);
			rightBoxList.appendChild(li);
		}
		rightBox.appendChild(rightBoxList);
		rightBoxListItems = rightBoxList.children;
		addFilterEventHandlers(filter);
	}

	function addFilterEventHandlers(filter) {
		filter.addEventListener('keyup', function() {
			var searchValue = this.value.toLowerCase();
			for (var i = 0, len = rightBoxListItems.length; i < len; i += 1) {
				var li = rightBoxListItems[i];
				var image = li.children[1];
				if (image.title.toLowerCase().indexOf(searchValue) > -1) {
					li.style.display = '';
				} else {
					li.style.display = 'none';
				}
			}
		});
	}

	function addImageEventHandlers(img) {
		img.addEventListener('click', function(evt) {
			leftBoxImage.src = this.src;
			leftBoxTitle.innerHTML = this.title;
		});

		img.addEventListener('mouseover', function(evt) {
			img.parentNode.style.background = 'rgb(202,202,202)';

		});

		img.addEventListener('mouseout', function(evt) {
			img.parentNode.style.background = '';
		});
	}
}