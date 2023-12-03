using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class BaiHoc
    {
        public BaiHoc()
        {
            NoiDungs = new HashSet<NoiDung>();
        }

        public int Id { get; set; }
        public string TenBaiHoc { get; set; }
        public int? MonHocId { get; set; }
        public int? DonViId { get; set; }

        public virtual DonVi DonVi { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual ICollection<NoiDung> NoiDungs { get; set; }
    }
}
