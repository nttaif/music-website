//Bắt sự kiện click vào nút tim;



var isPlay = false;
var playerBtn = document.getElementById("playBtn-control");
var pauseBtn = document.getElementById("pauseBtn-control");
// xử lý cd quay khi phát nhạc
var media_cd = document.getElementById("media-cd");
var media_cd_Animate = media_cd.animate([
    { transform: "rotate(360deg)" },
], {
    duration: 10000,
    iterations: Infinity,
},)
media_cd_Animate.pause();
//Nhấn vào nút phát nhạc
function playSong() {
    isPlay = true;
    audio.play();
    playerBtn.classList.add("d-none");
    pauseBtn.classList.add("d-block");
    media_cd_Animate.play();
}
// Pause song
function pauseSong() {
    isPlay = false;
    audio.pause();
    playerBtn.classList.remove("d-none");
    pauseBtn.classList.remove("d-block");
    media_cd_Animate.pause();
    
}
clickPlayorPause = function () {
    if (!isPlay) {
        playSong();
    } else {
        pauseSong();
    }
}
//Map thanh scroll vào trong audio
    