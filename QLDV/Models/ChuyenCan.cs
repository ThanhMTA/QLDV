using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class ChuyenCan
    {
        public int HocVienId { get; set; }
        public int IdKhhl { get; set; }
        public int? CoMat { get; set; }
        public int? VangMat { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual Khhl IdKhhlNavigation { get; set; }
    }
}
