using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProveVarie.DataAccess
{
    public class CarnetEntityFrameworkRepository : IRepository<Carnet>
    {
        private AppDbContext _context;

        public CarnetEntityFrameworkRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(Carnet model)
        {
            _context.Carnets.Remove(model);
            var result = _context.SaveChanges();
            return result == 1;
        }

        public Carnet Find(int id)
        {
            var result = _context.Carnets.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public List<Carnet> FindAll()
        {
            var models = _context.Carnets.Include(x => x.MealVouchers).ToList();
            return models;
        }

        public void Insert(Carnet model)
        {
            _context.Carnets.Add(model);
            _context.SaveChanges();
        }

        public bool Update(Carnet model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public List<Carnet> DateFilter(DateTime dateMin, DateTime dateMax)
        {
            var delivered = _context.Carnets.Where(x => x.AssignmentDate != null)
                .ToList();

            var filtered = delivered.Where(
               x => x.AssignmentDate >= dateMin &&
               x.AssignmentDate <= dateMax).ToList();
            
            return filtered;
        }

        public List<cc> CostCenterFilter(int costCenterId)
        {
            var joined = _context.Carnets.Join(
                _context.CostCenters,
                currentCarnet => currentCarnet.CostCenterID,
                currentCostCenter => currentCostCenter.ID,
                (currentCarnet, currentCostCenter)
                => new cc { Carnet = currentCarnet, CostCenter = currentCostCenter }).ToList();

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
                .Where(x => x.Carnet.AssignmentDate != null &&
            x.CostCenter.ID == costCenterId).ToList();



            return filtered;
        }

        public List<Carnet> CostCenter_And_Date_Filter(DateTime minDate, DateTime maxDate, CostCenter costCenter)
        {
            var specificCC = CostCenterFilter(costCenter.ID);
            var R = specificCC.Where(x => x.Carnet.AssignmentDate > minDate && x.Carnet.AssignmentDate < maxDate);

            return R.Select(x => x.Carnet).ToList();
        }
    }
}