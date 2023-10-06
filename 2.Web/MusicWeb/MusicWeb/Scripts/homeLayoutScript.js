/*xử lí sự kiện dừng và phát nhạc*/
var playBtn = document.getElementById("play");
var audio = document.getElementById("audio-control");
var pauseBtn = document.getElementById("stop")
var checkPlay;
var playAudio = function () {
    audio.play();
    checkPlay = true;
};
var pauseAudio = function () {
    audio.pause();
    checkPlay = false;
}
playBtn.addEventListener("click", playAudio, false);
pauseBtn.addEventListener("click", pauseAudio, false)
/*xử lí sự kiện kéo thả thanh control-time và currentTime durranTime*/
/*let time = document.getElementById("playback-position");
let curr=audio.currentTime
audio.ontimeupdate = function () { myFunction() };
audio.ontimeupdate = function () {myFunction()}
function myFunction()
{
    time.innerHTML(curr);
}*/