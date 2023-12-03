using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class NhomDaoTao
    {
        public NhomDaoTao()
        {
            HocViens = new HashSet<HocVien>();
            KhoaHocs = new HashSet<KhoaHoc>();
        }

        public int Id { get; set; }
        public string TenNhom { get; set; }
        public double? ThoiLuong { get; set; }

        public virtual ICollection<HocVien> HocViens { get; set; }
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
