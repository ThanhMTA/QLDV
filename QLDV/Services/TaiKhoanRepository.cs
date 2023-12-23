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
    public class TaiKhoanRepository : TaiKhoanInterface
    {
        private readonly HeThongContext _context;

        public TaiKhoanRepository(HeThongContext context)
        {
            _context = context;
        }
        #region add
        public void Add(TaiKhoanView TB)
        {
            var tenTk = TB.TenTk;
            var mk = TB.Mk;
            var idCanBo = TB.IdCb;
            var idQuyen = _context.Quyens
                     .Where(lo => lo.Ten == TB.Quyen)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();

            _context.Database.ExecuteSqlInterpolated($"exec  AddTaiKhoan {tenTk},{mk},{idCanBo},{idQuyen}");
        }
        #endregion
        #region delete 

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec DeleteTaiKhoan {id}");
        }
        #endregion
        #region getall
        public List<TaiKhoanView> GetAll()
        {
            var subordinates = new List<TaiKhoanView>();

            string proc = "exec GetALLTaiKhoan";
            var loais = _context.TaiKhoans.FromSqlRaw(proc).ToList();

            foreach (var subUnit in loais)
            {
            

                subordinates.Add(new TaiKhoanView
                {
                    Id = subUnit.Id,
                    TenTk=subUnit.TenTk,
                    Mk=subUnit.Mk,
                    IdCb=subUnit.IdCb,
                    CanBo = _context.CanBoes
                    .Where(lo => lo.Id == subUnit.IdCb)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault(),
                    Quyen = _context.Quyens
                    .Where(lo => lo.Id == subUnit.IdQuyen)
                    .Select(lo => lo.Ten)
                    .SingleOrDefault()
                });



            }
            return subordinates;
        }
        #endregion
       
      
        #region Update 
        public void Update(TaiKhoanView TB)
        {
            var id = TB.Id;
            var tenTk = TB.TenTk;
            var mk = TB.Mk;
            var idCanBo = TB.IdCb;

            var idQuyen = _context.Quyens
                     .Where(lo => lo.Ten == TB.Quyen)
                     .Select(lo => lo.Id)
                     .SingleOrDefault();

            _context.Database.ExecuteSqlInterpolated($"exec  UpdateTaiKhoan {id}, {tenTk},{mk},{idCanBo},{idQuyen}");
        }
        #endregion

    }
}
