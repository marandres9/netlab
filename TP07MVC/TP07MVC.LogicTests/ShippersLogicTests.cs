using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP04_EntityFramework.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TP04_EntityFramework.Data;
using TP04_EntityFramework.Entity;
using System.Data.Entity;

namespace TP04_EntityFramework.Logic.Tests
{
    [TestClass()]
    public class ShippersLogicTests
    {
        // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
        [TestMethod()]
        public void AddTest()
        {
            var mockSet = new Mock<DbSet<Shippers>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Shippers).Returns(mockSet.Object);

            var logic = new ShippersLogic(mockContext.Object);
            logic.Add(new Shippers { ShipperID = 1, CompanyName = "TestAdd Shippers", Phone = "123-987456" });

            // verifica que los metodos Add() y SaveChanges() han sido llamados al menos una vez
            mockSet.Verify(m => m.Add(It.IsAny<Shippers>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}