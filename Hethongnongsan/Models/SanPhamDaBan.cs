using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Hethongnongsan.Models
{
    public partial class SanPhamDaBan
    {
        public int Idsanphamdaban { get; set; }
        public string Idsp { get; set; }
        public DateTime? Ngayban { get; set; }
        public string Idshop { get; set; }
        public string Diachi { get; set; }
        public double? Tongtien { get; set; }
        public int? Idnguoimua { get; set; }
        public string Tensanpham { get; set; }
        public string Idshopcart { get; set; }
    }
}
