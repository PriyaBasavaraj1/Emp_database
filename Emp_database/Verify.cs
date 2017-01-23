using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_database
{
    public class InvalidInputException : System.Exception
    {
        public InvalidInputException(string s) : base(s)
        {
        }

    }
    public class Verify
    {

        public static bool verify(string firstName, string lastName, string email)
        {
            string error = "";
            if (string.IsNullOrEmpty(firstName))
                error += "First Name cannot be empty \n";
            if (string.IsNullOrEmpty(lastName))
                error += "Last Name Cannot be empty\n";
            if (string.IsNullOrEmpty(email))
                error += "Email id cannot be empty \n";
            if (error != "")
            {
                throw (new InvalidInputException(error));
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
                throw (new InvalidInputException("Invalid Email Id"));
            }
        }
    }
}