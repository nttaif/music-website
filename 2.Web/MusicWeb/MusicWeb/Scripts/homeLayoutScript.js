/// <reference path="jquery.js" />
//Bắt sự kiện click vào nút tim;
var isPlay = false;
var playerBtn = document.getElementById("playBtn-control");
var pauseBtn = document.getElementById("pauseBtn-control");
var song = document.getElementById("audio");
var progress = document.getElementById("progress");
var sourceAudio = document.getElementById("srcAudio");
var nameSong = document.getElementById("nameSong");
var nameSinger = document.getElementById("nameSinger");
var imgmedia = document.getElementById("imgMedia");
// xử lý cd quay khi phát nhạc
var media_cd = document.getElementById("media-cd");
var media_cd_Animate = media_cd.animate([
    { transform: "rotate(360deg)" },
], {
    duration: 10000,
    iterations: Infinity,
},)
media_cd_Animate.pause();


//xử lí khi nhấn vào bài hát thì thay source trong audio
// Hàm để thay đổi nguồn (source)
function changeAudioSource(newSourceUrl, namesong, namesinger, newimage, ID_Song) {
    if (song) {
        sourceAudio.src = newSourceUrl;
        song.load(); // Tải lại nguồn mới
        isPlay = false;
        clickPlayorPause();
        song.play();
        $.ajax({
            url: '/Home/UpdateView',
            type: 'POST',
            data: { ID_Song: ID_Song },
            error: function (xhr, status, error) {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                alert(error);
            }
        });
        nameSong.textContent = namesong;
        nameSinger.textContent = namesinger;
        imgmedia.src = newimage;


    } else {
        console.error('Không tìm thấy phần tử audio.');
    }
}

//Nhấn vào nút phát nhạc
function playSong() {
    isPlay = true;
    audio.play();
    playerBtn.classList.add("d-none");
    pauseBtn.classList.add("d-block");
    progress.value = song.currentTime;
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
//THANH AUDIO NHẠC
// Hàm để cập nhật thanh tiến trình của bài hát
function updateProgress() {
    var progress = document.getElementById('progress');
    var currentTimeElement = document.querySelector('.controls_time--right');
    var durationTimeElement = document.querySelector('.controls_time--left');
    var audio = document.getElementById('audio');

    progress.value = (audio.currentTime / audio.duration) * 100;
    currentTimeElement.textContent = formatTime(audio.currentTime);
    durationTimeElement.textContent = formatTime(audio.duration);
}

// Hàm để định dạng thời gian từ giây sang phút:giây
function formatTime(seconds) {
    var minutes = Math.floor(seconds / 60);
    var seconds = Math.floor(seconds % 60);
    return minutes + ':' + (seconds < 10 ? '0' + seconds : seconds);
}

// Hàm để xử lý sự kiện khi người dùng kéo thanh tiến trình
function onProgressChange(e) {
    var audio = document.getElementById('audio');
    audio.currentTime = (e.target.value / 100) * audio.duration;
}

// Thêm sự kiện 'timeupdate' vào đối tượng audio
var audio = document.getElementById('audio');
audio.addEventListener('timeupdate', updateProgress);

// Thêm sự kiện 'change' vào thanh tiến trình
var progress = document.getElementById('progress');
progress.addEventListener('change', onProgressChange);

//ÂM THANH
// Hàm để xử lý sự kiện khi người dùng kéo thanh điều chỉnh âm lượng
function onVolumeChange(e) {
    var audio = document.getElementById('audio');
    audio.volume = e.target.value / 100;
}

// Thêm sự kiện 'input' vào thanh điều chỉnh âm lượng
var volumeRange = document.getElementById('controls_lever_range');
volumeRange.addEventListener('input', onVolumeChange);

//REPLAY
// Hàm để xử lý sự kiện replay
function replaySong() {
    var audio = document.getElementById('audio');
    audio.currentTime = 0; // Đặt thời gian hiện tại của audio về 0
    playSong(); // Phát bài hát
}

// Thêm sự kiện 'click' vào nút replay
var replayBtn = document.getElementById("replayBtn");
replayBtn.addEventListener('click', function () {
    var audio = document.getElementById('audio');
    audio.currentTime = 0;
    playSong();
});

function toggleMenu() {
    var menu = document.getElementById("subMenu");
    menu.classList.toggle("open-menu");
}
//click tim add library
// Lấy phần tử biểu tượng trái tim theo id
var checklike = false;
function toggleLike(button, idsong, iduser) {
    button.classList.toggle("liked");
    $.ajax({
        url: '/Home/AddSongInLibrary',
        type: 'POST',
        data: {
            ID_Song: idsong,
            ID_AdminUser: iduser
        },
        error: function (xhr, status, error) {
            // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
            alert("Vui lòng đăng nhập để thêm bài hát vào thư viện");
        }
    });
}


//đăng xuất
var outBtn = document.getElementById("outBtn")
outBtn.onclick = function () {
    $.ajax({
        url: '/Account/Logout',
        type: 'POST',
        /*data: { ID_Song: ID_Song },*/
        error: function (xhr, status, error) {
            // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
            alert(error);
        }
    });
}

function renderLibrary(data) {
    return ` <li class="list-group-item">
                    <a href="#"  class="nav-link">
                        <img src="${data.song.ImageSong}" width="50" height="50">
                        <marquee direction="right" width="40%">
                            <b>${data.song.Name_Song}</b>
                        </marquee>
                        <span>${data.song.Name_singer}</span>
                    </a>
                </li>`;

}


function getSongList() {
    $.ajax({
        url: "/Home/GetSongList",
        method: "GET",
        dataType: "json",
    }).done(function (result) {
        const data = JSON.parse(result.data);
        if (result != 0) {
            for (let i = 0; i < data.length; i++) {
                let html = renderLibrary(data[i]);
                $("#nav-lib-mussic").append(html);
            }


        } else {
            console.log(result.message)
        }
    }).fail(function (err) {

    });
}

$(document).ready(function () {
    getSongList();
})

function commingSoon() {
    alert("Comming Soon");
}

