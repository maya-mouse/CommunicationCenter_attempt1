using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security.Identity;
using DAL.UnitOfWork;
using Moq;
using Xunit;
using System.IO;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using User = CCL.Security.Identity.User;
using CCL.Security;


namespace BLL.Tests
{
    public class CabinetServicesTest
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
            () => new CabinetService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetCabinets_UserIsClient_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Client(1, 2, "хтось", "такий", "пошта1");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            ICabinetService cabinetService = new CabinetService(mockUnitOfWork.Object);
            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => cabinetService.GetCabinets(0));
        }

        [Fact]
        public void GetCabinet_CabinetFromDAL_CorrectMappingToCabinetDTO()
        {
            // Arrange
            User user = new Specialist(1, 2, "робітник", "якийсь", "непишітьсюди");
            SecurityContext.SetUser(user);
            var cabinetService = GetCabinetService();
            // Act
            var actualCabinetDto = cabinetService.GetCabinets(0).First();
            // Assert
            Assert.True(
            actualCabinetDto.CabinetID == 4
            );
        }
        ICabinetService GetCabinetService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedCabinet = new Cabinet()
            {
                CabinetID = 4,
            };
            var mockDbSet = new Mock<ICabinetRepository>();
            mockDbSet
            .Setup(z =>
            z.Find(
            It.IsAny<Func<Cabinet, bool>>(),
            It.IsAny<int>(),
            It.IsAny<int>()))
            .Returns(
            new List<Cabinet>() { expectedCabinet }
            );
            mockContext
            .Setup(context =>
            context.Cabinets)
            .Returns(mockDbSet.Object);
            ICabinetService cabinetService = new CabinetService(mockContext.Object);
            return cabinetService;
        }
    }
}
