using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveVarie.DataAccess
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T Find(int id);
        bool Update(T model);
        void Insert(T model);
        bool Delete(T model);
    }
}
