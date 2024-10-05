/// <reference path="jquery.js" />
function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}
// read file image
function ShowImagesReview(imgUploader, previewImage) {
    if (imgUploader.files && imgUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imgUploader.files[0])
    }
}