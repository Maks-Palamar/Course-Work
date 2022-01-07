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
    public class PositionsServicesTests
    {
        [TestMethod()]
        public void GetTopFivePositionTest()
        {
            //Arrange
            PositionsServices positionsServices = new PositionsServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = positionsServices.GetTopFivePosition();

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBestEmployeeTest()
        {
            //Arrange
            PositionsServices positionsServices = new PositionsServices();
            string actual;
            string expected = string.Empty;

            //Act
            actual = positionsServices.GetBestEmployee("test");

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}