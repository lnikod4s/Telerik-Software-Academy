var canvas = document.getElementById('bicycle-canvas'),
	ctx = canvas.getContext('2d');

ctx.lineWidth = 3;
ctx.fillStyle = '#90cad7';
ctx.strokeStyle = '#22545f';

ctx.beginPath();
ctx.arc(100, 200, 60, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.arc(210, 200, 20, 0, 2 * Math.PI);
ctx.stroke();

ctx.beginPath();
ctx.arc(370, 200, 60, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(370, 200);
ctx.lineTo(350, 80);
ctx.moveTo(400, 50);
ctx.lineTo(350, 80);
ctx.lineTo(290, 90);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(100, 200);
ctx.lineTo(210, 200);
ctx.lineTo(355, 120);
ctx.lineTo(180, 120);
ctx.lineTo(100, 200);
ctx.moveTo(210, 200);
ctx.lineTo(170, 90);
ctx.lineTo(150, 90);
ctx.lineTo(190, 90);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(195, 185);
ctx.lineTo(180, 170);
ctx.stroke();

ctx.beginPath();
ctx.moveTo(225, 215);
ctx.lineTo(240, 230);
ctx.stroke();