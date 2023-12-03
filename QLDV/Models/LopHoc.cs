using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class LopHoc
    {
        public LopHoc()
        {
            HocVienLopHocs = new HashSet<HocVienLopHoc>();
        }

        public int Id { get; set; }
        public string TenLopHoc { get; set; }
        public int? QuanSo { get; set; }
        public string DiaDiem { get; set; }
        public int? GiaoVienChinhId { get; set; }
        public int? GiaoVienId { get; set; }
        public int? HocKiId { get; set; }

        public virtual CanBo GiaoVien { get; set; }
        public virtual CanBo GiaoVienChinh { get; set; }
        public virtual HocKi HocKi { get; set; }
        public virtual ICollection<HocVienLopHoc> HocVienLopHocs { get; set; }
    }
}
