using Microsoft.EntityFrameworkCore;
using QLDV.Interfaces;
using QLDV.Models;
using QLDV.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLDV.Services
{
    public class NhomTBRepository : NhomTBInterface
    {
        private readonly HeThongContext _context;

        public NhomTBRepository(HeThongContext context)
        {
            _context = context;
        }
        public void  Add(NhomTBView loai)
        {
            var tenNhom = loai.TenNhom;
            _context.Database.ExecuteSqlInterpolated($"exec AddNhomTB {tenNhom}");
        }
    

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteNhomTB {id}");
        }
        public List<NhomTBView> GetAll()
        {
            var subordinates = new List<NhomTBView>();

            string proc = "exec GetAllNhomTB";
            var loais = _context.NhomTbs.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new NhomTBView
                {
                    Id = subUnit.Id,
                    TenNhom = subUnit.TenNhom,

                });



            }
            return subordinates;
        }

        public List<NhomTBView> Search(string search)
        {
            var subordinates = new List<NhomTBView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.NhomTbs.FromSqlRaw("SearchNhomTB {0}", search).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new NhomTBView
                {
                    Id = subUnit.Id,
                    TenNhom = subUnit.TenNhom,

                });



            }


            return subordinates;
        }

        public void Update(NhomTBView loai)
        {
            var tenNhom = loai.TenNhom;
            var id = loai.Id;
            _context.Database.ExecuteSqlInterpolated($"exec UpdateNhomTB {id}, {tenNhom}");
        }
    }
}
