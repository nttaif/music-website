using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class Singer
    {
        public Singer()
        {
            ImageSinger = "~/Content/images/images.jpg";
        }
        [DisplayName("ID ca sĩ")]
        public int ID_Singer { get; set; }
        [DisplayName("Tên ca sĩ")]
        public string Name_singer { get; set; }
        [DisplayName("Tiểu sử")]
        public string Story { get; set; }
        [DisplayName("Lượt xem hàng tháng")]
        public int View_moth { get; set; }
        [DisplayName("Ảnh ca sĩ")]
        public string ImageSinger { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}