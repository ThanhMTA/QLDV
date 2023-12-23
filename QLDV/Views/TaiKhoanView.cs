using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Views
{
    public class TaiKhoanView
    {
        public int Id { get; set; }
        public string TenTk { get; set; }
        public string Mk { get; set; }
        public string CanBo { get; set; }
        public int? IdCb { get; set; }

        public string Quyen { get; set; }
    }
}
