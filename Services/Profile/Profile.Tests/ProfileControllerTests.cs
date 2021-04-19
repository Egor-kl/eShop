using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Profile.API.Common.Interfaces;
using Profile.API.Controllers;
using Profile.API.DTO;
using Serilog;
using Xunit;

namespace Profile.Tests
{
    public class ProfileControllerTests : ControllerTestFixture
    {
        //[Fact]
        //public async void RegisterNewProfile_WithValidModel_Returns_CreatedAtActionResult()
        //{
        //    var profileServiceMock = new Mock<IProfileService>();
        //    profileServiceMock.Setup(service => service
        //            .RegisterNewProfileAsync(It.IsAny<IProfileDTO>()))
        //            .Returns(Task.FromResult((1, true)));

        //    var loggerMock = new Mock<ILogger>();
        //    loggerMock.Setup(c => c.Information(It.IsAny<string>()));

        //    var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
        //    var profileDTO = new ProfileDTO();

        //    // Act
        //    var result = await controller.RegisterNewProfile(IProfileDTO);

        //    // Assert
        //    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        //    Assert.IsAssignableFrom<ProfileDTO>(createdAtActionResult.Value);
        //}
        
        //[Fact]
        //public async void RegisterNewProfile_WithInvalidModel_Returns_BadRequestResult()
        //{
        //    // Arrange
        //    var profileServiceMock = new Mock<IProfileService>();
        //    var loggerMock = new Mock<ILogger>();

        //    var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
        //    controller.ModelState.AddModelError("Error", "Model Error");
        //    var profileDTO = new ProfileDTO();

        //    // Act
        //    var result = await controller.RegisterNewProfile(profileDTO);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}
        
        //[Fact]
        //public async void RegisterNewProfile_WithValidExistingModel_Returns_ConflictResult()
        //{
        //    // Arrange
        //    var profileServiceMock = new Mock<IProfileService>();
        //    profileServiceMock.Setup(service => service
        //            .RegisterNewProfileAsync(It.IsAny<IProfileDTO>()))
        //            .Returns(Task.FromResult((1, false)));

        //    var loggerMock = new Mock<ILogger>();
        //    loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

        //    var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);

        //    // Act
        //    var result = await controller.RegisterNewProfile(IProfileDTO);

        //    // Assert
        //    Assert.IsType<ConflictObjectResult>(result);
        //}
        
        [Fact]
        public async void UpdateProfile_WithInvalidModel_Returns_BadRequestResult()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();
            var loggerMock = new Mock<ILogger>();

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            controller.ModelState.AddModelError("Error", "Model Error");
            var profileDTO = new ProfileDTO();

            // Act
            var result = await controller.UpdateProfile(profileDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void UpdateProfile_WithUpdateError_Returns_ConflictObjectResult()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();

            profileServiceMock.Setup(service => service
                .GetProfileByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetProfile()));

            profileServiceMock.Setup(service => service
                .UpdateProfileAsync(It.IsAny<ProfileDTO>()))
                .Returns(Task.FromResult(false));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            var profileDTO = GetProfile();

            // Act
            var result = await controller.UpdateProfile(profileDTO);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public async Task UpdateProfile_WithValidModel_Returns_OkResult()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();

            profileServiceMock.Setup(service => service
                .GetProfileByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetProfile()));

            profileServiceMock.Setup(service => service
                .UpdateProfileAsync(It.IsAny<ProfileDTO>()))
                .Returns(Task.FromResult(true));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            var profileDTO = GetProfile();

            // Act
            var result = await controller.UpdateProfile(profileDTO);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<ProfileDTO>(okResult.Value);
        }

        [Fact]
        public async void GetProfiles_Returns_CollectionOfProfileDTO()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();
            profileServiceMock.Setup(service => service
                    .GetAllProfilesAsync())
                    .Returns(Task.FromResult(GetAllProfiles()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetProfiles();

            // Assert
            Assert.IsType<List<ProfileDTO>>(result);
        }

        [Fact]
        public async void GetProfile_WithValidModelAndValidId_Returns_ProfileDTO()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();
            profileServiceMock.Setup(service => service
                    .GetProfileByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(GetProfile()));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            var id = 1;

            // Act
            var result = await controller.GetProfileById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<ProfileDTO>(okObjectResult.Value);
        }
        
        [Fact]
        public async void GetProfile_WithInvalidModel_Returns_BadRequestResult()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();
            profileServiceMock.Setup(service => service
                    .GetProfileByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(GetProfile()));

            var loggerMock = new Mock<ILogger>();

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            controller.ModelState.AddModelError("Id", "InvalidId");

            var id = 12345123;

            // Act
            var result = await controller.GetProfileById(id);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        public async void DeleteProfile_WithInvalidModelId_Returns_NotFoundResult()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();
            profileServiceMock.Setup(service => service
                    .DeleteProfileByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(false));


            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Warning(It.IsAny<string>()));

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            var profileDTO = new ProfileDTO();
            var id = 444;

            // Act
            var result = await controller.DeleteProfileById(id);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.IsAssignableFrom<int>(notFoundObjectResult.Value);
        }

        [Fact]
        public async void DeleteProfile_Returns_OkResult()
        {
            // Arrange
            var profileServiceMock = new Mock<IProfileService>();

            profileServiceMock.Setup(service => service
                    .GetProfileByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(GetProfile()));

            profileServiceMock.Setup(service => service
                    .DeleteProfileByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(true));

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(c => c.Information(It.IsAny<string>()));

            var controller = new ProfileController(profileServiceMock.Object, loggerMock.Object);
            var id = 123;

            // Act
            var result = await controller.DeleteProfileById(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<int>(okObjectResult.Value);
        }
    }
}