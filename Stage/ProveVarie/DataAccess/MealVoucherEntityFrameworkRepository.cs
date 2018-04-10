using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProveVarie.DataAccess
{
    public class MealVoucherEntityFrameworkRepository : IRepository<MealVoucher>
    {
        private AppDbContext _context;

        public MealVoucherEntityFrameworkRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(MealVoucher model)
        {
            _context.MealVouchers.Remove(model);
            var result = _context.SaveChanges();
            return result == 1;
        }

        public MealVoucher Find(int id)
        {
            var result = _context.MealVouchers.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public List<MealVoucher> FindAll()
        {
            var models = _context.MealVouchers.Include(x => x.Carnet).ToList();
            return models;
        }

        public void Insert(MealVoucher model)
        {
            _context.MealVouchers.Add(model);
            _context.SaveChanges();
        }

        public bool Update(MealVoucher model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public List<MealVoucher> DateFilter(DateTime dateMin, DateTime dateMax)
        {
            var assigned = _context.MealVouchers.Where(x => x.UseDate != null)
                .ToList();

            var filtered = assigned.Where(
               x => x.UseDate >= dateMin &&
               x.UseDate <= dateMax).ToList();

            return filtered;
        }

        public List<mc> CostCenterFilter(int costCenterId)
        {
            var joined = _context.MealVouchers.Join(
                _context.CostCenters,
                currentMealVoucher => currentMealVoucher.ID,
                currentCostCenter => currentCostCenter.ID,
                (currentMealVoucher, currentCostCenter)
                => new mc { MealVoucher = currentMealVoucher, CostCenter = currentCostCenter }).ToList();

            //.Select(
            //    x => new
            //    {
            //        Stockist = x.Carnet.Stockist,
            //        Barcode = x.Carnet.Barcode,
            //        DeliveryDate = x.Carnet.DeliveryDate,
            //        RegistrationDate = x.Carnet.RegistrationDate,
            //        Name = x.CostCenter.Name
            //    });

            var filtered = joined
                .Where(x => x.MealVoucher.UseDate != null &&
            x.CostCenter.ID == costCenterId).ToList();



            return filtered;
        }

        public List<MealVoucher> CostCenter_And_Date_Filter(DateTime minDate, DateTime maxDate, CostCenter costCenter)
        {
            var specificCC = CostCenterFilter(costCenter.ID);
            var R = specificCC.Where(x => x.MealVoucher.AssignementDate > minDate && x.MealVoucher.AssignementDate < maxDate);

            return R.Select(x => x.MealVoucher).ToList();
        }

    }
}