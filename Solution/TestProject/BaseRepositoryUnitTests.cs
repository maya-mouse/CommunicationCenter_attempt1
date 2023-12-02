using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using System.Diagnostics.Metrics;
using Moq;

namespace DAL.Tests
{
    class TestCabinetRepository
 : BaseRepository<Cabinet>
    {
        public TestCabinetRepository(DbContext context)
        : base(context)
        {
        }
    }
    public class BaseRepositoryUnitTests
    {
        
        [Fact]
        public void Create_inputCabinetInstance_CalledAddMethodOfDBSetCabinetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<CommunicationCenterContext>().Options;
            var mockContext = new Mock<CommunicationCenterContext>(opt);
            var mockDbSet = new Mock<DbSet<Cabinet>>();
            mockContext.Setup(context =>context.Set<Cabinet>()).Returns(mockDbSet.Object);
            var repository = new TestCabinetRepository(mockContext.Object);
            Cabinet expectedCabinet = new Mock<Cabinet>().Object;
            //Act
            repository.Create(expectedCabinet);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expectedCabinet), Times.Once());
            //mockDbSet.Verify(dbSet => dbSet.Add(expectedCabinet), Times.Never());
        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<CommunicationCenterContext>().Options;
            var mockContext = new Mock<CommunicationCenterContext>(opt);
            var mockDbSet = new Mock<DbSet<Cabinet>>();
            mockContext.Setup(context =>context.Set<Cabinet>()).Returns(mockDbSet.Object);
            Cabinet expectedCabinet = new Cabinet();
         /*   {
                CabinetID = 3
            };*/
            mockDbSet.Setup(mock => mock.Find(expectedCabinet.CabinetID)).Returns(expectedCabinet);
            var repository = new TestCabinetRepository(mockContext.Object);
            //Act
            var actualCabinet = repository.Get(expectedCabinet.CabinetID);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedCabinet.CabinetID), Times.Once());
            Assert.Equal(expectedCabinet, actualCabinet);
        }
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<CommunicationCenterContext>().Options;
            var mockContext = new Mock<CommunicationCenterContext>(opt);
            var mockDbSet = new Mock<DbSet<Cabinet>>();
            mockContext.Setup(context =>context.Set<Cabinet>()).Returns(mockDbSet.Object);
            var repository = new TestCabinetRepository(mockContext.Object);
            Cabinet expectedCabinet = new Cabinet() { CabinetID = 2 };
            mockDbSet.Setup(mock => mock.Find(expectedCabinet.CabinetID)).Returns(expectedCabinet);
            //Act
            repository.Delete(expectedCabinet.CabinetID);
            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedCabinet.CabinetID), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedCabinet), Times.Once());
    
        }
    }
}
