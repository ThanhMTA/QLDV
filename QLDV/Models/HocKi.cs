using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class HocKi
    {
        public HocKi()
        {
            LopHocs = new HashSet<LopHoc>();
        }

        public int Id { get; set; }
        public string NamHoc { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? NamHocId { get; set; }

        public virtual NamHoc NamHocNavigation { get; set; }
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
