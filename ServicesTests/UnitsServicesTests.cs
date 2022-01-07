using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class UnitsServicesTests
    {
        [TestMethod()]
        public void GetUnitInfoTest()
        {
            //Arrange
            UnitsServices unitsServices = new UnitsServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = unitsServices.GetUnitInfo("2");

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}