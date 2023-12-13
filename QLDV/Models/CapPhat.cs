using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class CapPhat
    {
        public int Id { get; set; }
        public DateTime? NgayCap { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public int? DonViId { get; set; }
        public int? ThietBiId { get; set; }

        public virtual DonVi DonVi { get; set; }
        public virtual ThietBi ThietBi { get; set; }
    }
}
