using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Hethongnongsan.Models
{
    public partial class Shop
    {
        public int Idshop { get; set; }
        public int? Idchusohuu { get; set; }
        public DateTime? Ngaythanhlap { get; set; }
        public string Gioithieu { get; set; }
        public string Logo { get; set; }
        public string Tenshop { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
    }
}
