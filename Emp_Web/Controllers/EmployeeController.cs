using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Emp_Web.Models;
using Emp_database;

namespace Emp_Web.Controllers
{
    public class EmployeeController : ApiController
    {
        static readonly IEmployeeRepository employeeRepository = new EmployeeRepository();

        public HttpResponseMessage GetAllEmployees()
        {
            List<Emp_db> empList = employeeRepository.GetAll().ToList();
            return Request.CreateResponse<List<Emp_db>>(HttpStatusCode.OK, empList);
        }

        public HttpResponseMessage GetEmplopyee(string id)
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


        public HttpResponseMessage PostEmployee(Emp_db employee)
        {
            if (String.IsNullOrEmpty(employee.FirstName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please fill all the details");

            }
            bool result = employeeRepository.Add(employee);
            if (result)
            {
                var response = Request.CreateResponse<Emp_db>(HttpStatusCode.Created, employee);
                string uri = Url.Link("DefaultApi", new { id = employee.ID });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "");
            }
        }

        public HttpResponseMessage PutEmployee(Emp_db employee)
        {

            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage PutEmployee(string id, Emp_db employee)
        {
            employee.ID = id;
            if (!employeeRepository.Update(employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteProduct(string id)
        {
            employeeRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}