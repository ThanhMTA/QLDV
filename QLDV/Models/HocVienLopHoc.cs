using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class HocVienLopHoc
    {
        public int HocVienId { get; set; }
        public int LopHocId { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual LopHoc LopHoc { get; set; }
    }
}
