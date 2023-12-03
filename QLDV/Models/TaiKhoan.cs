using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.Models
{
    public partial class TaiKhoan
    {
        public int Id { get; set; }
        public string TenTk { get; set; }
        public string Mk { get; set; }
        public int? IdCb { get; set; }

        public virtual CanBo IdCbNavigation { get; set; }
    }
}
