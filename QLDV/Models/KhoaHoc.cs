using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class KhoaHoc
    {
        public KhoaHoc()
        {
            HocViens = new HashSet<HocVien>();
        }

        public int Id { get; set; }
        public string TenKhoa { get; set; }
        public DateTime? Ngaybatdau { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public int? IdNhomDaoTao { get; set; }

        public virtual NhomDaoTao IdNhomDaoTaoNavigation { get; set; }
        public virtual ICollection<HocVien> HocViens { get; set; }
    }
}
