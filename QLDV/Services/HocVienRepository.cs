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
    public class HocVienRepository : HocVienInterface
    {
        private readonly HeThongContext _context;

        public HocVienRepository(HeThongContext context)
        {
            _context = context;
        }
        #region add
        public void Add(HocVienView TB)
        {
            var tenHV = TB.Ten;
            var ngaysinh = TB.Ngaysinh;
            var quequan = TB.Quequan;
            var capbac = TB.CapBac;
            var sdt = TB.Sdt;
            var cccd = TB.Cccd;
            var idDonVi = _context.DonVis
                     .Where(lo => lo.Ten == TB.DonVi)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();

            _context.Database.ExecuteSqlInterpolated($"exec  AddHV {tenHV},{ ngaysinh},{quequan},{capbac},{sdt},{cccd},{idDonVi}");
        }
        #endregion
        #region delete 

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteHV {id}");
        }
        #endregion
        #region getall
        public List<HocVienView> GetAll()
        {
            var subordinates = new List<HocVienView>();

            string proc = "exec GetALLHV";
            var loais = _context.HocViens.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {


                subordinates.Add(new HocVienView
                {
                    Id = subUnit.Id,
                    Ten = subUnit.Ten,
                    Ngaysinh = subUnit.Ngaysinh,
                    Quequan = subUnit.Quequan,
                    CapBac = subUnit.CapBac,
                    Sdt=subUnit.Sdt,
                    Cccd=subUnit.Cccd,
                    DonVi = _context.DonVis
                    .Where(lo => lo.Id == subUnit.IdDonVi)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion
        #region Filter 
        public List<HocVienView> Filter( int idDV)
        {
            var subordinates = new List<HocVienView>();


            var loais = _context.HocViens.FromSqlRaw(" FilterHV {0}",  idDV).ToList();

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
        #endregion
        #region search 
        public List<HocVienView> Search(string search, int idDV)
        {
            var subordinates = new List<HocVienView>();

            // Lấy đơn vị dựa trên ID



            var subordinateUnits = _context.HocViens.FromSqlRaw("SearchHV {0},{1}", search,idDV).ToList();

            foreach (var subUnit in subordinateUnits)
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
        #endregion
        #region Update 
        public void Update(HocVienView TB)
        {
            var id = TB.Id;
            var tenHV = TB.Ten;
            var ngaysinh = TB.Ngaysinh;
            var quequan = TB.Quequan;
            var capbac = TB.CapBac;
            var sdt = TB.Sdt;
            var cccd = TB.Cccd;
            var idDonVi = _context.DonVis
                     .Where(lo => lo.Ten == TB.DonVi)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();
            _context.Database.ExecuteSqlInterpolated($"UpdateHV {id}, {tenHV},{ ngaysinh},{quequan},{capbac},{sdt},{cccd},{idDonVi}");
        }
        #endregion

    }
}
