using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
    public interface ThietBiInterface
    {
        List<ThietBiView> GetAll();
        List<ThietBiView> Filter(int idLoaiTB, int idDV);

        void Add(ThietBiView loai);
        void Update(ThietBiView loai);
        void Delete(int id);
        List<ThietBiView> Search(string search);
    }
}
