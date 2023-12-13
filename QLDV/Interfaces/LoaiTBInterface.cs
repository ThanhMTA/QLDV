using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface LoaiTBInterface
    {
        List<LoaiTBView> GetAll();
        void Add(LoaiTBView loai);
        void Update(LoaiTBView loai);
        void Delete(int id);
        List<LoaiTBView> Search(string search);
    }
}
