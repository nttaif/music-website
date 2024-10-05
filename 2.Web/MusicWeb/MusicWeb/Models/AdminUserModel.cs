using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class AdminUserModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("Tên đăng nhập")]
        public string NameUser { get; set; }
        [DisplayName("Email")]
        public string EmailUser { get; set; }
        [DisplayName("Quyền")]
        public string RoleUser { get; set; }
        [DisplayName("Mật khẩu")]
        public string PasswordUser { get; set; }
    }
}