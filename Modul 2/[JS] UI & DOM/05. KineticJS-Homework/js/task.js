(function() {
	window.onload = function() {
		var stage,
			layer,
			frame,
			grandfatherRect,
			grandmotherRect,
			fatherRect,
			motherRect,
			maleChild,
			femaleChild,
			curvedLine1,
			curvedLine2,
			curvedLine3,
			curvedLine4,
			curvedLine5;

		stage = new Kinetic.Stage({
			container: 'container',
			width: 640,
			height: 480
		});

		layer = new Kinetic.Layer();

		frame = new Kinetic.Rect({
			x: 0,
			y: 0,
			width: 640,
			height: 480,
			stroke: 'forestgreen',
			strokeWidth: 20
		});

		grandfatherRect = new Kinetic.Rect({
			x: 150,
			y: 20,
			width: 100,
			height: 50,
			stroke: 'forestgreen',
			strokeWidth: 5,
			cornerRadius: 10
		});

		grandmotherRect = new Kinetic.Rect({
			x: 350,
			y: 20,
			width: 100,
			height: 50,
			stroke: 'forestgreen',
			strokeWidth: 5,
			cornerRadius: 20
		});

		fatherRect = new Kinetic.Rect({
			x: 50,
			y: 150,
			width: 100,
			height: 50,
			stroke: 'forestgreen',
			strokeWidth: 5,
			cornerRadius: 10
		});

		motherRect = new Kinetic.Rect({
			x: 250,
			y: 150,
			width: 100,
			height: 50,
			stroke: 'forestgreen',
			strokeWidth: 5,
			cornerRadius: 20
		});

		maleChild = new Kinetic.Rect({
			x: 180,
			y: 280,
			width: 100,
			height: 50,
			stroke: 'forestgreen',
			strokeWidth: 5,
			cornerRadius: 10
		});

		femaleChild = new Kinetic.Rect({
			x: 380,
			y: 280,
			width: 100,
			height: 50,
			stroke: 'forestgreen',
			strokeWidth: 5,
			cornerRadius: 20
		});

		curvedLine1 = new Kinetic.Line({
			points: [200, 70, 220, 100, 300, 100, 300, 150],
			stroke: 'forestgreen',
			strokeWidth: 2,
			lineJoin: 'round',
			tension: 1
		});

		curvedLine2 = new Kinetic.Line({
			points: [400, 70, 380, 100, 300, 100, 300, 150],
			stroke: 'forestgreen',
			strokeWidth: 2,
			lineJoin: 'round',
			tension: 1
		});

		curvedLine3 = new Kinetic.Line({
			points: [100, 200, 120, 230, 200, 230, 230, 280],
			stroke: 'forestgreen',
			strokeWidth: 2,
			lineJoin: 'round',
			tension: 1
		});

		curvedLine4 = new Kinetic.Line({
			points: [300, 200, 280, 230, 200, 230, 230, 280],
			stroke: 'forestgreen',
			strokeWidth: 2,
			lineJoin: 'round',
			tension: 1
		});

		curvedLine5 = new Kinetic.Line({
			points: [300, 200, 320, 230, 400, 230, 430, 280],
			stroke: 'forestgreen',
			strokeWidth: 2,
			lineJoin: 'round',
			tension: 1
		});

		layer.add(frame);
		layer.add(grandfatherRect);
		layer.add(grandmotherRect);
		layer.add(fatherRect);
		layer.add(motherRect);
		layer.add(maleChild);
		layer.add(femaleChild);
		layer.add(curvedLine1);
		layer.add(curvedLine2);
		layer.add(curvedLine3);
		layer.add(curvedLine4);
		layer.add(curvedLine5);

		return stage.add(layer);
	};
}());