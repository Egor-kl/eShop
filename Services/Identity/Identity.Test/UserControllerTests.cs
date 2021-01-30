using System;
using System.Collections.Generic;
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
    public class UserControllerTests : ControllerTestFixture
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

        [Fact]
        public async void Login_WithValidModel_Returns_Accepted()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                    .LoginAsync(It.IsAny<LoginDTO>()))
                    .Returns(Task.FromResult(GetToken()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var loginDTO = GetLoginData();

            controller.ControllerContext = GetFakeContext();

            // Act
            var result = await controller.Login(loginDTO);

            // Assert
            var acceptedResult = Assert.IsType<AcceptedResult>(result);
            Assert.IsAssignableFrom<TokenDTO>(acceptedResult.Value);
        }
        
        [Fact]
        public async void Login_WhenAccountDoesNotExist_Returns_NoContentResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                    .LoginAsync(It.IsAny<LoginDTO>()))
                    .Returns(Task.FromResult(GetNullToken()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var loginDTO = GetLoginData();

            // Act
            var result = await controller.Login(loginDTO);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        
        [Fact]
        public void Login_WithValidModel_Returns_AcceptedResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                    .LoginAsync(It.IsAny<LoginDTO>()))
                    .Returns(Task.FromResult(GetToken()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var loginDTO = GetLoginData();

            controller.ControllerContext = GetFakeContext();

            // Act
            var result = controller.Login(loginDTO).GetAwaiter().GetResult();

            // Assert
            var acceptedResult = Assert.IsType<AcceptedResult>(result);
            Assert.IsAssignableFrom<TokenDTO>(acceptedResult.Value);
        }
        
        [Fact]
        public async void UpdateAccount_WithInvalidModel_Returns_BadRequestResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var loggerMock = new Mock<ILogger>();

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            controller.ModelState.AddModelError("Error", "Model Error");
            var userDTO = new UserDTO();

            // Act
            var result = await controller.UpdateAccount(userDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void UpdateAccount_WhenAccountDoesNotExist_Returns_NotFoundResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                .GetUserByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetNullAccount()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var userDTO = GetAccount();

            // Act
            var result = await controller.UpdateAccount(userDTO);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.IsAssignableFrom<int>(notFoundObjectResult.Value);
        }

        [Fact]
        public async void UpdateAccount_WithUpdateError_Returns_ConflictResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(service => service
                .GetUserByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetAccount()));

            userServiceMock.Setup(service => service
                .UpdateUserAsync(It.IsAny<UserDTO>()))
                .Returns(Task.FromResult(false));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var userDTO = GetAccount();

            // Act
            var result = await controller.UpdateAccount(userDTO);

            // Assert
            Assert.IsType<ConflictResult>(result);
        }

        [Fact]
        public void UpdateAccount_WithValidModel_Returns_OkResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(service => service
                .GetUserByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(GetAccount()));

            userServiceMock.Setup(service => service
                .UpdateUserAsync(It.IsAny<UserDTO>()))
                .Returns(Task.FromResult(true));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var userDTO = GetAccount();

            // Act
            var result = controller.UpdateAccount(userDTO).GetAwaiter().GetResult();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<UserDTO>(okResult.Value);
        }

        [Fact]
        public async void DeleteAccount_WithInvalidModelId_Returns_NotFoundResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service
                .DeleteUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(false));

            var loggerMock = new Mock<ILogger>();

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var id = 123;

            // Act
            var result = await controller.DeleteAccountById(id);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.IsAssignableFrom<int>(notFoundObjectResult.Value);
        }

        [Fact]
        public async void DeleteAccount_Returns_OkResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(service => service
                .GetUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetAccount()));

            userServiceMock.Setup(service => service
                .DeleteUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            var loggerMock = new Mock<ILogger>();

            var controller = new UserController(userServiceMock.Object, loggerMock.Object);
            var id = 123;

            // Act
            var result = await controller.DeleteAccountById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
        }
        
        [Fact]
        public async void GetAccounts_Returns_CollectionOfAccountDTO()
        {
            // Arrange
            var accountServiceMock = new Mock<IUserService>();
            accountServiceMock.Setup(service => service
                .GetAllUsersAsync())
                .Returns(Task.FromResult(GetAllAccounts()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new UserController(accountServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAccounts();

            // Assert
            Assert.IsType<List<UserDTO>>(result);
        }

        [Fact]
        public async void GetAccount_WithInvalidModel_Returns_BadRequestResult()
        {
            // Arrange
            var accountServiceMock = new Mock<IUserService>();
            accountServiceMock.Setup(service => service
                .GetUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetAccount()));

            var loggerMock = new Mock<ILogger>();

            var controller = new UserController(accountServiceMock.Object, loggerMock.Object);
            controller.ModelState.AddModelError("Id", "InvalidId");

            var id = 12345123;

            // Act
            var result = await controller.GetAccountById(id);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void GetAccount_WithValidModelAndValidId_Returns_AccountDTO()
        {
            // Arrange
            var accountServiceMock = new Mock<IUserService>();
            accountServiceMock.Setup(service => service
                .GetUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetAccount()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new UserController(accountServiceMock.Object, loggerMock.Object);
            var id = 1;

            // Act
            var result = await controller.GetAccountById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<UserDTO>(okObjectResult.Value);
        }

        [Fact]
        public async void GetAccount_WithValidModelAndInvalidId_Returns_NoContentResult()
        {
            // Arrange
            var accountServiceMock = new Mock<IUserService>();
            accountServiceMock.Setup(service => service
                .GetUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetNullAccount()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new UserController(accountServiceMock.Object, loggerMock.Object);
            var id = 1;

            // Act
            var result = await controller.GetAccountById(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}