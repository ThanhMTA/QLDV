using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class DiemDanh
    {
        public int HocVienId { get; set; }
        public int LichHlid { get; set; }
        public int Comat { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual LichHl LichHl { get; set; }
    }
}
