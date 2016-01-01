$ ->
	($ '.dropdown .chosen').on 'click', (ev) ->
		ul = ($ this).next()
		isExpanded = ul.hasClass('expanded')
		($ '.expanded').removeClass 'expanded'
		if(!isExpanded)
			ul.addClass 'expanded'
			console.log ($ this)
			($ this).addClass 'expanded'
	($ '.dropdown ul li').on 'click', (ev) ->
		value = ($ this).html()
		chosen = ($ this).parent().prev()
		chosen.html value
		($ this).parent().removeClass 'expanded'

