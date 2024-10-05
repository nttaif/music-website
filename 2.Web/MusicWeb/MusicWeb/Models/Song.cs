using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MusicWeb.Models
{
    public class Song
    {
        public Song()
        {
            ImageSong = "~/Content/images/images.jpg";
        }
        [DisplayName("ID bài hát")]
        public int ID_Song { get; set; }
        [DisplayName("Tên bài hát")]
        public string Name_Song { get; set; }
        [DisplayName("ID thể loại")]
        public int ID_Catergory { get; set; }
        [DisplayName("Ngày phát hành")]
        public System.DateTime Release_Date { get; set; }
        [DisplayName("Bài hát")]
        public string Audio_Song { get; set; }
        [DisplayName("Hình ảnh bài hát")]
        public string ImageSong { get; set; }
        [DisplayName("Lượt xem")]
        public int View_Song { get; set; }
        [DisplayName("ID ca sĩ")]
        public int ID_Singer { get; set; }
        public virtual Singer Singer { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload {  get; set; }
        [NotMapped]
        public HttpPostedFileBase AudioUpload { get; set; }
        [NotMapped]
        public string Name_singer { get; set; }
        [NotMapped]
        public bool IsLiked = false;
    }
}