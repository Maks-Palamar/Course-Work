using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories.Tests
{
    [TestClass()]
    public class UnitsRepositoryTests
    {
        [TestMethod()]
        public void GetUnitsTest()
        {
            //Arrange
            UnitsRepository unitsRepository = new UnitsRepository();
            List<Unit> units;

            //Act
            units = unitsRepository.GetUnits();

            //Assert
            Assert.IsNotNull(units);
        }
    }
}