using System.Threading.Tasks;
using Identity.Common.Interfaces;
using Identity.Controllers;
using Identity.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using Xunit;

namespace Identity.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void RegisterNewAccount_WithValidModel_Returns_CreatedAtActionResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                    .RegisterAsync(It.IsAny<UserDTO>()))
                    .Returns(Task.FromResult((1, true, "Success")));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var userDTO = new UserDTO();

            // Act
            var result = await controller.RegisterNewAccount(userDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsAssignableFrom<UserDTO>(createdAtActionResult.Value);
        }
        
        [Fact]
        public async void RegisterNewAccount_WithInvalidModel_Returns_BadRequestResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var loggerMock = new Mock<ILogger>();

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            controller.ModelState.AddModelError("Error", "Model Error");
            var userDTO = new UserDTO();

            // Act
            var result = await controller.RegisterNewAccount(userDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        public async void RegisterNewAccount_WithValidExistingModel_Returns_ConflictResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                    .RegisterAsync(It.IsAny<UserDTO>()))
                    .Returns(Task.FromResult((1, false, "Conflict")));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var userDTO = new UserDTO();

            // Act
            var result = await controller.RegisterNewAccount(userDTO);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }
    }
}