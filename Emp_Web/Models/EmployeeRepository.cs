﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emp_database;
using System.Web.Http;

namespace Emp_Web.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Emp_db> employees;
        DataClasses1DataContext connection = new DataClasses1DataContext();
        public EmployeeRepository()
        { }

        public IEnumerable<Emp_db> GetAll()
        {
            employees = (from s in connection.Emp_dbs select s).ToList();
            return employees;
        }

        public Emp_db Get(string id)
        {

            return (from s in connection.Emp_dbs where s.ID == id select s).FirstOrDefault();
        }

        [HttpPost]
        public bool Add(Emp_db employee)
        {
            connection.Emp_dbs.InsertOnSubmit(employee);
            connection.SubmitChanges();
            return true;
        }

        public void Remove(string id)
        {
            Emp_db employee = (from s in connection.Emp_dbs where s.ID == id select s).FirstOrDefault();
            if (employee.Status == "Activated")
                throw new Exception("Only deactivated Employees can be deleted");
            connection.Emp_dbs.DeleteOnSubmit((from s in connection.Emp_dbs where s.ID == id select s).FirstOrDefault());
            connection.SubmitChanges();
        }

        public bool Update(Emp_db employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }
            Emp_db s = (from t in connection.Emp_dbs
                             where t.ID == employee.ID
                             select t).FirstOrDefault();
            s.FirstName = employee.FirstName;
            s.LastName = employee.LastName;
            s.Status = employee.Status;

            connection.SubmitChanges();
            return true;
        }


    }
}