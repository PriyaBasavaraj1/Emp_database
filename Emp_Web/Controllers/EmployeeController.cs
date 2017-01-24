using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Emp_Web.Models;

namespace Emp_Web.Controllers
{
    public class EmployeeController : ApiController
    {
        static readonly IEmployeeRepository employeeRepository = new EmployeeRepository();

        public EmployeeController()
        {

        }

        public HttpResponseMessage GetAll()
        {
            List<Emp_db> empList = employeeRepository.GetAll().ToList();
            return Request.CreateResponse<List<Emp_db>>(HttpStatusCode.OK, empList);
        }

        public HttpResponseMessage Get(string id)
        {
            Emp_db employee = employeeRepository.Get(id);
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not found for the Given ID");
            }

            else
            {
                return Request.CreateResponse<Emp_db>(HttpStatusCode.OK, employee);
            }
        }


        public HttpResponseMessage Post(Emp_db employee)
        {
            Verifier obj = new Verifier();
            if (obj.InsertEmployee(employee) == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill all the details");

            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(Emp_db employee)
        {
            DataClasses1DataContext connection = new DataClasses1DataContext();
            Emp_db obj = (from s in connection.Emp_dbs where s.ID == employee.ID select s).FirstOrDefault();
            employee.Email = obj.Email;
            Verifier obj1 = new Verifier();

            if (obj1.UpdateEmployee(employee) == 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");

            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }


        public HttpResponseMessage Delete(string id)
        {
            employeeRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}