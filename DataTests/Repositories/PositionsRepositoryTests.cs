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
    public class PositionsRepositoryTests
    {
        [TestMethod()]
        public void GetPositionsTest()
        {
            //Arrange
            PositionsRepository positionsRepository = new PositionsRepository();
            List<Position> positions;

            //Act
            positions = positionsRepository.GetPositions();

            //Assert
            Assert.IsNotNull(positions);
        }
    }
}