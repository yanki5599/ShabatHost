using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatHost.Reposetory
{
    internal interface IRepository<T>
    {
        List<T> GetAll();
        T? FindById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
