using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class LibraryModel
    {
        [DisplayName("ID Library")]
        public int ID_Library { get; set; }
        [DisplayName("ID User")]
        public int ID_AdminUser { get; set; }
        [DisplayName("ID bài hát")]
        public int ID_Song { get; set; }
        public Song song=new Song();
        public AdminUserModel adminUser = new AdminUserModel();
    }
}