using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Hethongnongsan.Models
{
    public partial class Nguoidung
    {
        public int Idnguoidung { get; set; }
        public string Tennguoidung { get; set; }
        public string Diachi { get; set; }
        public string Gioitinh { get; set; }
        public int? Idshop { get; set; }
        public int? Idshopcart { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Sodienthoai { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Roles { get; set; }
    }
}
