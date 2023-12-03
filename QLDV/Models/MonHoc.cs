using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            BaiHocs = new HashSet<BaiHoc>();
            Diems = new HashSet<Diem>();
        }

        public int Id { get; set; }
        public string TenMonHoc { get; set; }
        public int? TinChi { get; set; }
        public double? TongThoiLuong { get; set; }
        public int? IdKhhl { get; set; }

        public virtual Khhl IdKhhlNavigation { get; set; }
        public virtual ICollection<BaiHoc> BaiHocs { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}
