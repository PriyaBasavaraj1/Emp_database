using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emp_Web;
using Emp_Web.Models;
using Rhino.Mocks;

namespace Emp_test
{
    [TestClass]
    public class Emp_mockTests
    {
        [TestMethod]
        public void Post_withValidEntries_DoesnotThrowAnException()
        {
            Emp_Web.Emp_db obj1 = new Emp_Web.Emp_db();
            obj1.FirstName = "Priya";
            obj1.LastName = "B";
            obj1.Email = "priya@gmail.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            int res = mockEmpCrtl.InsertEmployee(obj1);
            Assert.AreEqual(1, res, "error");
        }

        [TestMethod]
        public void Post_withEmptyFirstName_ThrowsException()
        {
            Emp_Web.Emp_db obj1 = new Emp_Web.Emp_db();
            obj1.FirstName = "";
            obj1.LastName = "B";
            obj1.Email = "priya@gmail.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("First Name cannot be empty \n", e.Message);
            }
        }

        [TestMethod]
        public void Post_withEmptyLastName_ThrowsException()
        {
            Emp_Web.Emp_db obj1 = new Emp_Web.Emp_db();
            obj1.FirstName = "Priya";
            obj1.LastName = "";
            obj1.Email = "priya@gmail.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Last Name cannot be empty \n", e.Message);
            }
        }

        [TestMethod]
        public void Post_withEmptyEmail_ThrowsException()
        {
            Emp_Web.Emp_db obj1 = new Emp_Web.Emp_db();
            obj1.FirstName = "Priya";
            obj1.LastName = "B";
            obj1.Email = "";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email id cannot be empty \n", e.Message);
            }
        }

        [TestMethod]
        public void Post_withInvalidEmail_ThrowsException()
        {
            Emp_db obj1 = new Emp_db();
            obj1.FirstName = "Priya";
            obj1.LastName = "B";
            obj1.Email = "priya.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Add(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid Email Id", e.Message);
            }
        }

        [TestMethod]
        public void Put_withEmptyEmail_ThrowsException()
        {
            Emp_db obj1 = new Emp_db();
            obj1.ID = "1";
            obj1.FirstName = "Priya";
            obj1.LastName = "B";
            obj1.Email = "";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email id cannot be empty \n", e.Message);
            }

        }

        [TestMethod]
        public void Put_withEmptyLastName_ThrowsException()
        {
            Emp_db obj1 = new Emp_db();
            obj1.ID = "1";
            obj1.FirstName = "Priya";
            obj1.LastName = "";
            obj1.Email = "priya@gmail.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Last Name cannot be empty \n", e.Message);
            }

        }

        [TestMethod]
        public void Put_withEmptyFirstName_ThrowsException()
        {
            Emp_db obj1 = new Emp_db();
            obj1.ID = "1";
            obj1.FirstName = "";
            obj1.LastName = "B";
            obj1.Email = "priya@gmail.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("First Name cannot be empty \n", e.Message);
            }

        }

        [TestMethod]
        public void Put_withInavlidEmail_ThrowsException()
        {
            Emp_db obj1 = new Emp_db();
            obj1.ID = "1";
            obj1.FirstName = "Priya";
            obj1.LastName = "B";
            obj1.Email = "priya";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.Update(obj1)).Return(true);

            Verifier mockEmpCrtl = new Verifier(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.UpdateEmployee(obj1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid Email Id", e.Message);
            }

        }

        [TestMethod]
        public void Delete_withActivatedEmployee_ThrowsException()
        {
            Emp_db obj1 = new Emp_db();
            obj1.ID = "1";
            obj1.FirstName = "Priya";
            obj1.LastName = "B";
            obj1.Email = "priya@gmail.com";
            obj1.Status = "Activated";
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            try
            { 
                mockEmployeeRepository.Expect(x => x.Remove(obj1.ID));
            }
            catch (Exception e)
            {
                Assert.AreEqual("Only deactivated Employees can be deleted", e.Message);
            }

        }

        [TestMethod]
        public void Delete_withInvalidId_ThrowsException()
        {
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            try
            {
                mockEmployeeRepository.Expect(x => x.Remove("123"));
            }
            catch (Exception e)
            {
                Assert.AreEqual("Only deactivated Employees can be deleted", e.Message);
            }

        }
    }
}
    