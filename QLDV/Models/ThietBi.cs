using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class ThietBi
    {
        public int Id { get; set; }
        public string TenTb { get; set; }
        public int? IdLoaiTb { get; set; }
        public int? IdDonVi { get; set; }
        public string Donvi { get; set; }
        public int? SoLuong { get; set; }

        public virtual DonVi IdDonViNavigation { get; set; }
        public virtual LoaiTb IdLoaiTbNavigation { get; set; }
    }
}
