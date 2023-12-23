using QLDV.Models;
using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface TKInterface
    {
        List<TKDiemView> ThongKeDiem(int makh, int maDV);
    }
}
