using Mecalux.Models;
using Mecalux.Models.POCO;
using Mecalux.Service;
using Mecalux_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Transactions;

namespace Mecalux.Tests
{
    public class UnitControllersTest
    {
        private TextProcessController _controller;
        private Mock<ITextProcessService> _serviceMock;

        private string TestText = "Lorem ipsum dolor sit amet consectetur adipiscing";

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<ITextProcessService>();
            _controller = new TextProcessController(_serviceMock.Object);
        }

        [Test]
        public void GetOrderTypesIsNotEmpty()
        {
            // Arrange
            int NumberGivenByClass = Enum.GetNames(typeof(OrderOption)).Length;
            _serviceMock.Setup(x=> x.GetAllOrderTypes()).Returns(new List<string> { TestText });

            // Act
            var actionResult = _controller.GetOrderOptions();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
        [Test]
        public void GetOrderTypesIsEmpty()
        {
            // Arrange
            int NumberGivenByClass = Enum.GetNames(typeof(OrderOption)).Length;

            // Act
            var actionResult = _controller.GetOrderOptions();

            // Assert
            Assert.IsInstanceOf<NoContentResult>(actionResult);
        }

        [Test]
        public void GetOrderedTextReturnsOk()
        {
            // Arrange
            _serviceMock.Setup(x => x.isValidOrderOption("AlphabeticDesc")).Returns(true);

            // Act
            var actionResult = _controller.GetOrderedText(TestText,OrderOption.AlphabeticDesc.ToString());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
        [Test]
        public void GetStatisticsReturnsOk()
        {
            // Arrange
            _serviceMock.Setup(x => x.GenerateStatistics(TestText)).Returns(new TextStatistics(TestText));

            // Act
            var actionResult = _controller.GetStatistics(TestText);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
    }
}