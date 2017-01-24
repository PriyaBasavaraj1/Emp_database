using Emp_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emp_Web
{
    public class InvalidException : System.Exception
    {
        public InvalidException(string s) : base(s)
        {
        }

    }
    public class Verifier
    {
        private readonly IEmployeeRepository _emp;
        public Verifier()
        {
            _emp = new EmployeeRepository();
        }

        public Verifier(IEmployeeRepository employee)
        {
            if (employee != null)
                _emp = employee;
        }
        public IEnumerable<Emp_db> GetAll()
        {
            return _emp.GetAll();
        }

        public Emp_db Get(string EmployeeID)
        {
            return _emp.Get(EmployeeID);
        }

        public int InsertEmployee(Emp_db newEmployee)
        {
            verify(newEmployee.FirstName, newEmployee.LastName, newEmployee.Email);
            var status = _emp.Add(newEmployee);
            if (status == true)
                return 1;
            else
                return 0;
        }

        public int UpdateEmployee(Emp_db updateEmployee)
        {

            if (verify(updateEmployee.FirstName, updateEmployee.LastName, updateEmployee.Email))
                return 1;
            else
                return 0;

        }

        public static bool verify(string firstName, string lastName, string email)
        {
            string error = "";
            if (string.IsNullOrEmpty(firstName))
                error += "First Name cannot be empty \n";
            if (string.IsNullOrEmpty(lastName))
                error += "Last Name cannot be empty \n";
            if (string.IsNullOrEmpty(email))
                error += "Email id cannot be empty \n";
            if (error != "")
            {
                throw (new InvalidException(error));
            }
            IsValidEmail(email);

            return true;

        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                throw (new InvalidException("Invalid Email Id"));
            }
        }
    }
}