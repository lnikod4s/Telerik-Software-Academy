var canvas = document.getElementById('bicycle-canvas'),
	ctx = canvas.getContext('2d');

ctx.lineWidth = 3;
ctx.fillStyle = '#975b5b';
ctx.strokeStyle = 'black';

// Roof
ctx.beginPath();
ctx.moveTo(150, 200);
ctx.lineTo(350, 200);
ctx.lineTo(250, 100);
ctx.lineTo(150, 200);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(290, 170);
ctx.lineTo(290, 115);
ctx.lineTo(310, 115);
ctx.lineTo(310, 170);
ctx.fill();
ctx.stroke();

ctx.save();
ctx.scale(1, 0.3);
ctx.beginPath();
ctx.arc(300, 380, 10, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

// Base

ctx.rect(150, 200, 200, 160);
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(170, 360);
ctx.lineTo(170, 300);
ctx.quadraticCurveTo(195, 270, 220, 300);
ctx.lineTo(220, 360);
ctx.moveTo(195, 360);
ctx.lineTo(195, 285);
ctx.stroke();

ctx.beginPath();
ctx.arc(185, 330, 5, 0 , 2 * Math.PI);
ctx.stroke();


ctx.beginPath();
ctx.arc(205, 330, 5, 0 , 2 * Math.PI);
ctx.stroke();

ctx.fillStyle = 'black';
ctx.strokeStyle = '#975b5b';

ctx.save();
ctx.beginPath();
ctx.rect(160, 220, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(200, 220, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(160, 245, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(200, 245, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(260, 220, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(300, 220, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(260, 245, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(300, 245, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(260, 280, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(300, 280, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(260, 305, 35, 20);
ctx.fill();

ctx.save();
ctx.beginPath();
ctx.rect(300, 305, 35, 20);
ctx.fill();