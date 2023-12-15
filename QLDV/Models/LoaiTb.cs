using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class LoaiTb
    {
        public LoaiTb()
        {
            ThietBis = new HashSet<ThietBi>();
        }

        public int Id { get; set; }
        public string TenLoai { get; set; }
        public int? IdNhomTb { get; set; }
        public string Donvi { get; set; }
        public int? SoLuong { get; set; }

        public virtual NhomTb IdNhomTbNavigation { get; set; }
        public virtual ICollection<ThietBi> ThietBis { get; set; }
    }
}
