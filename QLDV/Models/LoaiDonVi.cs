using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class LoaiDonVi
    {
        public LoaiDonVi()
        {
            DonVis = new HashSet<DonVi>();
        }

        public int Id { get; set; }
        public string TenNhom { get; set; }

        public virtual ICollection<DonVi> DonVis { get; set; }
    }
}
