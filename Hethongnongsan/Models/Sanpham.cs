using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Hethongnongsan.Models
{
    public partial class Sanpham
    {
        public int Idsanpham { get; set; }
        public string Tensanpham { get; set; }
        public int? Idshop { get; set; }
        public string Tenloai { get; set; }
        public string Gioithieu { get; set; }
        public decimal? Gia { get; set; }
        public string Linkhinhanh { get; set; }
    }
}
