using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class HvKhhl
    {
        public int IdHv { get; set; }
        public int IdKhhl { get; set; }

        public virtual HocVien IdHvNavigation { get; set; }
        public virtual Khhl IdKhhlNavigation { get; set; }
    }
}
