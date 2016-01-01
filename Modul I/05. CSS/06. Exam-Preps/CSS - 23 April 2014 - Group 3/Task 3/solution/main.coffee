$ ->
	setCurrent = (el) ->
		title = el.data 'title'
		src = el.data 'src'
		($ '#large h1').text title
		($ '#large img').attr 'src', src
		($ '#list .current').removeClass 'current'
		el.addClass 'current'
	($ '#list ul li') .on 'click', (ev) ->
		setCurrent $ this
	($ '#btn-prev') .on 'click', (ev) ->
		index = ($ '#list .current').data('index')
		index--
		if index < 0
			index = 0
		prev = ($ '#list ul li[data-index=' + index + ']')
		setCurrent prev
	($ '#btn-next') .on 'click', (ev) ->
		index = ($ '#list .current').data('index')
		index++
		if index > 3
			index = 3
		next = ($ '#list ul li[data-index=' + index + ']')
		setCurrent next