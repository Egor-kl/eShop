using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Common.Interfaces;
using Catalog.API.Controllers;
using Catalog.API.DTO;
using Moq;
using Serilog;
using Xunit;

namespace Catalog.Tests
{
    public class CatalogControllerTests : ControllerTestFixture
    {
        [Fact]
        public async void GetAllItems_WithValidModel_Returns_CollectionOfItemDTO()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service.GetAllItems())
                .Returns(Task.FromResult<List<ItemDTO>>(GetAllItems()));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAllItems();

            // Assert
            Assert.IsType<List<ItemDTO>>(result);
        }
        
        [Fact]
        public async void GetAllItem_WithValidModel_Returns_ItemDTO()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service.GetItemById(3))
                .Returns(Task.FromResult<ItemDTO>(GetItem()));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetItemById(3);

            // Assert
            Assert.IsType<ItemDTO>(result);
        }
    }
}