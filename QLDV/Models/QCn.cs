using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class QCn
    {
        public int IdCn { get; set; }
        public int IdQuyen { get; set; }

        public virtual ChucNang IdCnNavigation { get; set; }
        public virtual Quyen IdQuyenNavigation { get; set; }
    }
}
