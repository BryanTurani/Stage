using ProveVarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProveVarie.DataAccess
{
    public class UserEntityFrameworkRepository : IRepository<User>
    {
        private AppDbContext _context;

        public UserEntityFrameworkRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(User model)
        {
            _context.Users.Remove(model);
            var result = _context.SaveChanges();
            return result == 1;
        }

        public User Find(int id)
        {
            var result = _context.Users.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public List<User> FindAll()
        {
            var models = _context.Users.Include(x => x.Role).ToList();
            return models;
        }

        public void Insert(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public bool Update(User model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}