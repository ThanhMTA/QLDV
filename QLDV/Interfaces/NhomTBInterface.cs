using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Interfaces
{
   public interface NhomTBInterface
    {
        List<NhomTBView> GetAll();
        void  Add(NhomTBView loai);
        void Update(NhomTBView loai);
        void Delete(int id);
        List<NhomTBView> Search(string search);
    }
}
