var canvas = document.getElementById("head-canvas"),
	ctx = canvas.getContext("2d"),
	gradient;

ctx.lineWidth = 3;
ctx.strokeStyle = "#22545f";
ctx.fillStyle = "#90cad7";

// Head
ctx.save();
ctx.scale(1, 0.9);
ctx.beginPath();
ctx.arc(250, 220, 80, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

// Nose
ctx.beginPath();
ctx.moveTo(245, 200);
ctx.lineTo(225, 200);
ctx.lineTo(245, 170);
ctx.stroke();

// Left eye
ctx.save();
ctx.scale(1, 0.3);
ctx.beginPath();
ctx.arc(210, 570, 15, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

ctx.save();
ctx.fillStyle = "#22545f";
ctx.scale(1, 0.3);
ctx.beginPath();
ctx.arc(210, 570, 7, 0, 2 * Math.PI);
ctx.fill();
ctx.restore();

// Right eye
ctx.save();
ctx.scale(1, 0.3);
ctx.beginPath();
ctx.arc(275, 570, 15, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

ctx.save();
ctx.fillStyle = "#22545f";
ctx.scale(1, 0.3);
ctx.beginPath();
ctx.arc(275, 570, 7, 0, 2 * Math.PI);
ctx.fill();
ctx.restore();

// Mouth
ctx.save();
ctx.scale(1, 0.4);
ctx.beginPath();
ctx.arc(240, 580, 20, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

ctx.strokeStyle = "black";
ctx.fillStyle = "#396693";

// Hat
ctx.save();
ctx.scale(1, 0.2);
ctx.beginPath();
ctx.arc(245, 680, 80, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

ctx.beginPath();
ctx.moveTo(290, 45);
ctx.lineTo(290, 125);
ctx.lineTo(210, 125);
ctx.lineTo(210, 45);
ctx.fill();
ctx.stroke();

ctx.save();
ctx.scale(1, 0.45);
ctx.beginPath();
ctx.arc(250, 100, 40, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

ctx.save();
ctx.scale(1, 0.45);
ctx.beginPath();
ctx.arc(250, 273, 40, 0, Math.PI);
ctx.fill();
ctx.stroke();
ctx.restore();

// Creating gradient
gradient = ctx.createLinearGradient(0, 0, canvas.width, 0);
gradient.addColorStop(0, "magenta");
gradient.addColorStop(0.5, "blue");
gradient.addColorStop(1.0, "red");

// Drawing a text
ctx.font = "80px Georgia";
ctx.fillStyle = gradient;
ctx.fillText("Such Wow", 50, 310);
ctx.fillText("Much Doge", 70, 350);