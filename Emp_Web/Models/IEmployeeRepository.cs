using System.Collections.Generic;

namespace Emp_Web.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Emp_db> GetAll();
        Emp_db Get(string id);
        bool Add(Emp_db employee);
        void Remove(string id);
        bool Update(Emp_db employee);
    }
}