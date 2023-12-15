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
        List<LoaiTBView> Filter(int id);
        void Add(LoaiTBView loai);
        void Update(LoaiTBView loai);
        void Delete(int id);
        List<LoaiTBView> Search(string search);
    }
}
