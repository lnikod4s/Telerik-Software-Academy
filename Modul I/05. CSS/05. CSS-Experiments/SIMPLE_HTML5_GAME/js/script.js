var globalAvatarImage = new Image();
var globalEnemyImage = new Image();
globalAvatarImage.src = "img/avatar.png";
globalEnemyImage.src = "img/enemy.png";

function drawAvatar() {
    var gameCanvas = document.getElementById("gameCanvas");
    var avatarImage = globalAvatarImage;

    gameCanvas.getContext("2d").drawImage(avatarImage, Math.random() * 100, Math.random() * 100);

    gameCanvas.addEventListener("mousemove", redrawAvatar);
}

function redrawAvatar(mouseEvent) {
    var gameCanvas = document.getElementById("gameCanvas");
    var avatarImage = globalAvatarImage;
    var enemyImage = globalEnemyImage;

    gameCanvas.width = 400;		//this erases the contents of the canvas
    gameCanvas.getContext("2d").drawImage(avatarImage, mouseEvent.offsetX, mouseEvent.offsetY);
    gameCanvas.getContext("2d").drawImage(enemyImage, 250, 150);

    //my avatar is 30px wide and the enemy is at x=250, so I have to check whether mouseEvent.offsetX is within 30px
    //either side of x=250 (i.e., from 220 to 280)
    //similarly, since my avatar is 33px tall, I have to check whether mouseEvent.offsetX is within 33px ABOVE y=150
    //but since enemy is only 30px tall, I also check whether mouseEvent.offsetX is within 30px BELOW y=150
    //therefore, I check from (117 to 180)
    if (mouseEvent.offsetX > 220 && mouseEvent.offsetX < 280 && mouseEvent.offsetY > 117 && mouseEvent.offsetY < 180) {
        alert("You hit the enemy!");
    }
}