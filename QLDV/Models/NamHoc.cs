using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class NamHoc
    {
        public NamHoc()
        {
            HocKis = new HashSet<HocKi>();
        }

        public int Id { get; set; }
        public string NamHoc1 { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public virtual ICollection<HocKi> HocKis { get; set; }
    }
}
