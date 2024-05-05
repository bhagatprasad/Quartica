using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Frameworks;
using Quartica.Web.Service.Controllers;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quatica.Web.Service.Test
{
    [TestFixture]
    public class MessageTypeControllerTests
    {
        private MessageTypeController _messageTypeController;
        private Mock<IMessageTypeService> _messageTypeServiceMock;
        private MessageType validmessageType = null;

        [SetUp]
        public void Setup()
        {
            _messageTypeServiceMock = new Mock<IMessageTypeService>();
            _messageTypeController = new MessageTypeController(_messageTypeServiceMock.Object);
        }
        public MessageTypeControllerTests()
        {
            this.validmessageType = new MessageType
            {
                Id = 1,
                Name = "Test MessageType",
                Code = "TEST",
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedBy = 1,
                ModifiedOn = DateTimeOffset.UtcNow,
                ModifiedBy = 1,
                IsActive = true
            };
        }
        [Test]
        public async Task FetchMessageTypesAsync_Returns_Ok()
        {
            //Arrange 
            var expectedResult = new List<MessageType>();
            expectedResult.Add(validmessageType);
            _messageTypeServiceMock.Setup(x => x.fetchMessageTypesAync()).ReturnsAsync(expectedResult);

            //Act
            var result = await _messageTypeController.fetchMessageTypesAync();
            Assert.IsNotNull(result);


            //Assert
            Assert.IsInstanceOf<ObjectResult>(result);

            var responce = result as OkObjectResult;

            Assert.IsNotNull(responce);

            Assert.AreEqual(expectedResult, responce.Value);

        }
        [Test]
        public async Task FetchMessageTypesAsync_Returns_InternalServer_On_Exception()
        {
            //Arrange
            _messageTypeServiceMock.Setup(x => x.fetchMessageTypesAync()).ThrowsAsync(new Exception("Test exception"));

            //Act
            var result = await _messageTypeController.fetchMessageTypesAync();


            //Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);

            var responce = result as StatusCodeResult;

            Assert.AreEqual(500,responce.StatusCode);
        }

        [Test]
        public async Task InsertOrUpdateMessageTypeAsync_Valid_MessageType_Insertion()
        {
            // Arrange

            _messageTypeServiceMock.Setup(x => x.InsertOrUpdateMessageTypeAsync(validmessageType)).ReturnsAsync(validmessageType);

            // Act
            var result = await _messageTypeController.InsertOrUpdateMessageTypeAsync(validmessageType);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
        }

       
    }
}