using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emp_database;

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