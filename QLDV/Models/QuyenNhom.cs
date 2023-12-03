using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class QuyenNhom
    {
        public int? IdNhom { get; set; }
        public int? IdQuyen { get; set; }

        public virtual Nhom IdNhomNavigation { get; set; }
        public virtual Quyen IdQuyenNavigation { get; set; }
    }
}
