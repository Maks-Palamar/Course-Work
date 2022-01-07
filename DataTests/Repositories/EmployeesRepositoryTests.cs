using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Tests
{
    [TestClass()]
    public class EmployeesRepositoryTests
    {
        [TestMethod()]
        public void GetEmployeesTest()
        {
            //Arrange
            EmployeesRepository employeesRepository = new EmployeesRepository();
            List<Employee> employees;

            //Act
            employees = employeesRepository.GetEmployees();

            //Assert
            Assert.IsNotNull(employees);
        }
    }
}