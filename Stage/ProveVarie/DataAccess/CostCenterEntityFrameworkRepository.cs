using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProveVarie.DataAccess
{
    public class CostCenterEntityFrameworkRepository : IRepository<CostCenter>
    {
        private AppDbContext _context;

        public CostCenterEntityFrameworkRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(CostCenter model)
        {
            _context.CostCenters.Remove(model);
            var result = _context.SaveChanges();
            return result == 1;
        }

        public CostCenter Find(int id)
        {
            var result = _context.CostCenters.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public List<CostCenter> FindAll()
        {
            var models = _context.CostCenters.Include(x => x.Carnets).ToList();
            return models;
        }

        public void Insert(CostCenter model)
        {
            _context.CostCenters.Add(model);
            _context.SaveChanges();
        }

        public bool Update(CostCenter model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}