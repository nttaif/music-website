using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Models
{
    public class SongViewModel
    {
        public Song song { get; set; }
        public string selectedCategory{ get; set; }
        public IEnumerable<SelectListItem> CategoryDropdownList { get; set; }
        public string selectedSinger { get; set; }
        public IEnumerable<SelectListItem> SingerDropList { get; set; }
    }
}