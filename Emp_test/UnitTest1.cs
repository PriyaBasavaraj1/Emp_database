using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emp_database;

namespace Emp_test
{
    [TestClass]
    public class UnitTest1
    {
        bool res;
        //public static bool Employeetesting(string firstName, string lastName, string email)
        //{

        //    return Verify.verify(firstName, lastName, email);
        //}
        [TestMethod]
        public void Entering_ValidInputs_DoesNotThrowAnException()
        {
            res = Verify.verify("Priya", "B", "pri@gmail.in");
            Assert.AreEqual(true, res, "error");
        }

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void Entering_InValidEmail_ThrowsInvalidInputException()
        {
            res = Verify.verify("Priya", "B", "pri");
            Assert.AreEqual(true, res, "error");
        }

        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void Empty_FirstName_ThrowsInvalidInputException()
        {
            res = Verify.verify("", "B", "pri@gmail.in");
            Assert.AreEqual(true, res, "error");
        }
        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void Empty_LastName_ThrowsInvalidInputException()
        {
            res = Verify.verify("Priya", "", "pri@gmail.in");
            Assert.AreEqual(true, res, "error");
        }



        [TestMethod, ExpectedException(typeof(InvalidInputException))]
        public void Empty_EmailId_ThrowsInvalidInputException()
        {
            res = Verify.verify("Priya", "B", "");
            Assert.AreEqual(true, res, "error");
        }

    }
}