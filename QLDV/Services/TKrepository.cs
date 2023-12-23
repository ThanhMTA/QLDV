using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QLDV.Interfaces;
using QLDV.Models;
using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Services
{
    public class TKrepository : TKInterface
    {
        private readonly HeThongContext _context;

        public TKrepository(HeThongContext context)
        {
            _context = context;
        }
        public List<TKDiemView> ThongKeDiem(int makh, int maDV)
        {
            var subordinates = new List<TKDiemView>();




             _context.Database.ExecuteSqlInterpolated($"ThongKeDiem {makh}, {maDV}");
            var loais = _context.Tkdiems.FromSqlRaw("getTKDiem ").ToList();



            foreach (var subUnit in loais)
            {

                float Gioi = (float) subUnit.Gioi;
                float Kha = (float)subUnit.Kha;
                float TrungBinh = (float) subUnit.TrungBinh;
                float Kem = (float)subUnit.Kem;
                float tong = Gioi + Kha + TrungBinh + Kem;
                float g = 0;
                float k = 0;
                float tb = 0;
                float ke = 0;
                // Làm tròn số với 2 chữ số thập phân
                if (Gioi != 0)
                {
                    g = (float)(Gioi * 100.0 / tong);
                    g = (float)Math.Round(g, 2); // Làm tròn với 2 chữ số thập phân
                }

                // Làm tròn số với 2 chữ số thập phân
                if (Kha != 0)
                {
                    k = (float)(Kha * 100.0 / tong);
                    k = (float)Math.Round(k, 2); // Làm tròn với 2 chữ số thập phân
                }

                // Làm tròn số với 2 chữ số thập phân
                if (TrungBinh != 0)
                {
                    tb = (float)(TrungBinh * 100.0 / tong);
                    tb = (float)Math.Round(tb, 2); // Làm tròn với 2 chữ số thập phân
                }

                // Làm tròn số với 2 chữ số thập phân
                if (Kem != 0)
                {
                    ke = (float)(Kem * 100.0 / tong);
                    ke = (float)Math.Round(ke, 2); // Làm tròn với 2 chữ số thập phân
                }


                subordinates.Add(new TKDiemView
                {
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDv)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault(),
                    Gioi = g,
                    Kha = k,
                    TrungBinh = tb,
                    Kem = ke
                }) ;



            }
            return subordinates;
        }
    }
}
