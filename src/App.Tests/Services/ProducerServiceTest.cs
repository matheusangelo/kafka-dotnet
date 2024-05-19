using Moq;
using FluentValidation;
using App.Application.Services;
using App.Domain.Entities;
using App.Application.Contracts;
using App.Domain.Repositories;
using AutoMapper;
using App.Application;

namespace App.Tests
{

    public class ProducerServiceTest
    {
        private Mock<IMessageReposity> _mockMessageRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<IValidator<Message>> _mockValidator;

        public ProducerServiceTest()
        {
            _mockMessageRepository = new Mock<IMessageReposity>();
            _mockMapper = new Mock<IMapper>();
            _mockValidator = new Mock<IValidator<Message>>();
        }

        [Fact]
        public void Test_CreateMessage_ValidInput_ReturnsMessage()
        {
            // Arrange
            
            _mockValidator.Setup(v => v.Validate(It.IsAny<Message>()))
                          .Returns(new FluentValidation.Results.ValidationResult());

            var mockAdapter = new Mock<IBrokerAdapter>();

            var service = new ProducerService(_mockMessageRepository.Object, 
                                              _mockMapper.Object, 
                                              _mockValidator.Object, 
                                              mockAdapter.Object);

            var dto = new CreateMessageDTO("Message Test");

            // Act
            var result = service.CreateMessage(dto);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_CreateMessage_InvalidInput_ThrowsValidationException()
        {
            // Arrange
            var validationErrors = new List<FluentValidation.Results.ValidationFailure> { 
                new FluentValidation.Results.ValidationFailure("Property", "Error message") 
            };
            _mockValidator.Setup(v => v.Validate(It.IsAny<Message>()))
                          .Returns(new FluentValidation.Results.ValidationResult(validationErrors));
            
            var mockAdapter = new Mock<IBrokerAdapter>();
            
            var service = new ProducerService(_mockMessageRepository.Object, 
                                              _mockMapper.Object, 
                                              _mockValidator.Object, 
                                              mockAdapter.Object);
            
            var dto = new CreateMessageDTO("Message Test");

            // Act & Assert
            Assert.Throws<ValidationException>(() => service.CreateMessage(dto));
        }

    }
}
