using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class QuyenTk
    {
        public int? IdTk { get; set; }
        public int? IdQuyen { get; set; }

        public virtual Quyen IdQuyenNavigation { get; set; }
        public virtual TaiKhoan IdTkNavigation { get; set; }
    }
}
