using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Tests
{
    [TestClass()]
    public class EmployeesServicesTests
    {
        [TestMethod()]
        public void GetEmployeeInfoTest()
        {
            //Arrange
            EmployeesServices employeesServices = new EmployeesServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = employeesServices.GetEmployeeInfo("1231231231");

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void GetEmployeeProjectsInfoTest()
        {
            //Arrange
            EmployeesServices employeesServices = new EmployeesServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = employeesServices.GetEmployeeProjectsInfo("1231231231");

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void GetSortedEmployeesInfoTest()
        {
            //Arrange
            EmployeesServices employeesServices = new EmployeesServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = employeesServices.GetSortedEmployeesInfo("Name");

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void GetEmployeesInfoTest()
        {
            //Arrange
            EmployeesServices employeesServices = new EmployeesServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = employeesServices.GetEmployeesInfo();

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        

    }
}