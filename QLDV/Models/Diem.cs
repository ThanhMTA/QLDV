using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class Diem
    {
        public int HocVienId { get; set; }
        public int Khhlid { get; set; }
        public double? Diem1 { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual Khhl Khhl { get; set; }
    }
}
