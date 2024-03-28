using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    // ממשק המתאר את הפעולות על הנתונים
    public interface IRepository<T>
    {
        public T Add(T entity);
        public T Update(int id, T entity);
        public void Delete(int id);
        public List<T> GetAll();
        public T Get(int id);
    }
}
