using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Common.Interfaces;
using Catalog.API.Controllers;
using Catalog.API.DTO;
using Microsoft.AspNetCore.Mvc;
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
            catalogServiceMock.Setup(service => service
                    .GetAllItems())
                    .Returns(Task.FromResult(GetAllItemsDTO()));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAllItems();

            // Assert
            Assert.IsType<List<ItemDTO>>(result);
        }
        
        [Fact]
        public async void GetItemById_WithValidModel_Returns_ItemDTO()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service
                    .GetItemById(3))
                    .Returns(Task.FromResult<ItemDTO>(GetItemDTO()));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetItemById(3);

            // Assert
            Assert.IsType<ItemDTO>(result);
        }

        [Fact]
        public async void GetAllCategories_WithValidModel_Returns_CollectionOfCategoryDTO()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service.GetAllCategories())
                .Returns(Task.FromResult<List<CategoryDTO>>(GetAllCategoriesDTO()));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAllCategories();

            // Assert
            Assert.IsType<List<CategoryDTO>>(result);
        }
        
        [Fact]
        public async void GetCategoryById_WithValidModel_Returns_CategoryDTO()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service.GetCategoryById(1))
                .Returns(Task.FromResult<CategoryDTO>(GetCategoryDTO()));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetCategoryById(1);

            // Assert
            Assert.IsType<CategoryDTO>(result);
        }

        [Fact]
        public async void AddNewCategoryWithValidModel_Returns_CreatedAtActionResult()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service
                    .AddNewCategory(It.IsAny<CategoryDTO>()))
                    .Returns(Task.FromResult((1, true)));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);
            var categoryDTO = new CategoryDTO();
            
            // Act
            var result = await controller.AddNewCategory(categoryDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsAssignableFrom<CategoryDTO>(createdAtActionResult.Value);
        }
        
        [Fact]
        public async void AddNewItemWithValidModel_Returns_CreatedAtActionResult()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            catalogServiceMock.Setup(service => service
                    .AddNewItem(It.IsAny<ItemDTO>()))
                    .Returns(Task.FromResult((1, true)));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);
            var itemDTO = new ItemDTO();
            
            // Act
            var result = await controller.AddNewItem(itemDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsAssignableFrom<ItemDTO>(createdAtActionResult.Value);
        }

        [Fact]
        public async void DeleteCategoryById_Returns_OkResult()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            
            catalogServiceMock.Setup(service => service
                    .GetCategoryById(It.IsAny<int>()))
                    .Returns(Task.FromResult(GetCategoryDTO()));
            
            catalogServiceMock.Setup(service => service
                    .DeleteCategoryById(It.IsAny<int>()))
                    .Returns(Task.FromResult(true));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);
            
            //Act
            var result = await controller.DeleteCategoryById(1);
            
            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
        }
        
        [Fact]
        public async void DeleteItemById_Returns_OkResult()
        {
            // Arrange
            var catalogServiceMock = new Mock<ICatalogService>();
            
            catalogServiceMock.Setup(service => service
                    .GetItemById(It.IsAny<int>()))
                    .Returns(Task.FromResult(GetItemDTO()));
            
            catalogServiceMock.Setup(service => service
                    .DeleteItemById(It.IsAny<int>()))
                    .Returns(Task.FromResult(true));
            
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new CatalogController(catalogServiceMock.Object, loggerMock.Object);
            
            //Act
            var result = await controller.DeleteItemById(3);
            
            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
        }
    }
}