using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Models
{
    public class Catergory
    {
        public Catergory() { }
        [DisplayName("ID")]
        public int ID_Catergory { get; set; }
        [DisplayName("Thể Loại")]
        public string Name_Catergory { get; set; }
        [NotMapped]
        public List<Catergory> Catecollection {  get; set; }
        [NotMapped]
        public IEnumerable<SelectList> listCater { get; set; }
    }
}