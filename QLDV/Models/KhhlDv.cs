using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class KhhlDv
    {
        public int IdDv { get; set; }
        public int IdKhhl { get; set; }

        public virtual DonVi IdDvNavigation { get; set; }
        public virtual Khhl IdKhhlNavigation { get; set; }
    }
}
