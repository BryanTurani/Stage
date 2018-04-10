using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProveVarie.DataAccess
{
    public class RoleEntityFrameworkRepository : IRepository<Role>
    {
        private AppDbContext _context;

        public RoleEntityFrameworkRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(Role model)
        {
            _context.Roles.Remove(model);
            var result = _context.SaveChanges();
            return result == 1;
        }

        public Role Find(int id)
        {
            var result = _context.Roles.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public List<Role> FindAll()
        {
            var models = _context.Roles.Include(x => x.Users).ToList();
            return models;
        }

        public void Insert(Role model)
        {
            _context.Roles.Add(model);
            _context.SaveChanges();
        }

        public bool Update(Role model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}