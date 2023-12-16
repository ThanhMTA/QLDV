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
    public class DVHLRepository : DVHLInterface
    {
        private readonly HeThongContext _context;

        public DVHLRepository(HeThongContext context)
        {
            _context = context;
        }
        public void Add(DVHLView loai)
        {
            var dv = _context.DonVis
                    .Where(lo => lo.Ten == loai.DonVi)
                    .Select(lo => lo.Id)
                    .SingleOrDefault();
            var khhl = loai.IdKhhl;

            _context.Database.ExecuteSqlInterpolated($"exec  AddDVHL {khhl},{dv}");

        }

        public void Delete(int khhl, int dv)
        {
            _context.Database.ExecuteSqlInterpolated($"exec  DeleteDVHL {khhl},{dv}");

        }

        public List<HocVienView> Filter(string  dv)
        {
            var subordinates = new List<HocVienView>();

            var idDV = _context.DonVis
                    .Where(lo => lo.Ten == dv)
                    .Select(lo => lo.Id)
                    .SingleOrDefault();
            var loais = _context.HocViens.FromSqlRaw($"GetHVHL {idDV}").ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new HocVienView
                {
                    Id = subUnit.Id,
                    Ten = subUnit.Ten,
                    Ngaysinh = subUnit.Ngaysinh,
                    Quequan = subUnit.Quequan,
                    CapBac = subUnit.CapBac,
                    Sdt = subUnit.Sdt,
                    Cccd = subUnit.Cccd,
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDonVi)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }

        public List<DVHLView> GetAll(int khhl)
        {
            var subordinates = new List<DVHLView>();


            var loais = _context.KhhlDvs.FromSqlRaw($"GetAllDVHL {khhl}").ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new DVHLView
                {
                    IdKhhl =subUnit.IdKhhl,
                    DonVi = _context.DonVis
                        .Where(lo => lo.Id == subUnit.IdDv)
                        .Select(lo => lo.Ten)
                        .SingleOrDefault()
                });



            }
            return subordinates;
        }

        public List<DVHLView> Search(string search, int khhl)
        {
          var subordinates = new List<DVHLView>();


                var loais = _context.KhhlDvs.FromSqlRaw($"SearchDVHL {search}, {khhl}").ToList();

                foreach (var subUnit in loais)
                {


                    subordinates.Add(new DVHLView
                    {
                        IdKhhl = subUnit.IdKhhl,
                        DonVi = _context.DonVis
                        .Where(lo => lo.Id == subUnit.IdDv)
                        .Select(lo => lo.Ten)
                        .SingleOrDefault()
                      
                    });



                }
                return subordinates;
            
        }
    }
}
