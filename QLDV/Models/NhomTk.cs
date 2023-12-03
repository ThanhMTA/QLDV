using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class NhomTk
    {
        public int? IdTk { get; set; }
        public int? IdNhom { get; set; }

        public virtual Nhom IdNhomNavigation { get; set; }
        public virtual TaiKhoan IdTkNavigation { get; set; }
    }
}
