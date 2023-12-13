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
    public class LoaiTBRepository : LoaiTBInterface
    {
        private readonly HeThongContext _context;

        public LoaiTBRepository(HeThongContext context)
        {
            _context = context;
        }
        public void Add(LoaiTBView loai)
        {
            var tenLoai = loai.TenLoai;
            _context.Database.ExecuteSqlInterpolated($"exec AddLoaiTB {tenLoai}");
        }


        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteLoaiTB {id}");
        }
        public List<LoaiTBView> GetAll()
        {
            var subordinates = new List<LoaiTBView>();

            string proc = "exec GetAllLoaiTB";
            var loais = _context.LoaiTbs.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new LoaiTBView
                {
                    Id = subUnit.Id,
                    TenLoai = subUnit.TenLoai,
                    TenNhomTB = _context.NhomTbs
                    .Where(lo => lo.Id == subUnit.IdNhomTb)
                    .Select(lo => lo.TenNhom)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }

        public List<LoaiTBView> Search(string search)
        {
            var subordinates = new List<LoaiTBView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.LoaiTbs.FromSqlRaw("SearchLoaiTB {0}", search).ToList();

            foreach (var subUnit in subordinateUnits)
            {


                subordinates.Add(new LoaiTBView
                {
                    Id = subUnit.Id,
                    TenLoai = subUnit.TenLoai,
                    TenNhomTB = _context.NhomTbs
                    .Where(lo => lo.Id == subUnit.IdNhomTb)
                    .Select(lo => lo.TenNhom)
                    .SingleOrDefault()
            });



            }


            return subordinates;
        }

        public void Update(LoaiTBView loai)
        {
            var tenLoai = loai.TenLoai;
            var idNhomTB = _context.NhomTbs
                    .Where(lo => lo.TenNhom == loai.TenNhomTB)
                    .Select(lo => lo.Id)
                    .SingleOrDefault();
            var id = loai.Id;
            _context.Database.ExecuteSqlInterpolated($"exec UpdateLoaiTB {id}, {tenLoai},{idNhomTB}");
        }
    }
}
