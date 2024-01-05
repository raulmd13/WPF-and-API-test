using Mecalux.Models;
using Mecalux.Models.POCO;
using Mecalux.Service;
using Mecalux_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Tests
{
    public class UnitServiceTest
    {
        private TextProcessService _textProcessService;

        private string TestText = "Lorem ipsum dolor sit amet consectetur adipiscing";

        public string TestTextOrderedAsc = "adipiscing amet consectetur dolor ipsum Lorem sit";
        public string TestTextOrderedLenghtAsc = "sit amet Lorem ipsum dolor adipiscing consectetur";
        public string TestTextOrderedDesc = "sit Lorem ipsum dolor consectetur amet adipiscing";

        public TextStatistics TestStatistics = new TextStatistics() { hyphensQuantity = 0, spacesQuantity = 6, wordQuantity = 7 };

        [SetUp]
        public void Setup()
        {
            _textProcessService = new TextProcessService();
        }

        [Test]
        public void GetOrderOptionCount()
        {
            // Act
            int NumberGivenByService = _textProcessService.GetAllOrderTypes().Count();

            int NumberGivenByClass = Enum.GetNames(typeof(OrderOption)).Length;

            // Assert
            Assert.AreEqual(NumberGivenByService, NumberGivenByClass);
        }

        [Test]
        public void NonValidOrderOption()
        {
            // Act
            bool result = _textProcessService.isValidOrderOption("test");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidOrderOption()
        {
            // Act
            bool result = _textProcessService.isValidOrderOption(OrderOption.AlphabeticDesc.ToString());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void OrderTextDesc()
        {
            // Act
            string result = _textProcessService.OrderText(TestText, OrderOption.AlphabeticDesc);

            // Assert
            Assert.AreEqual(result, TestTextOrderedDesc);
        }

        [Test]
        public void OrderTextAsc()
        {
            // Act
            string result = _textProcessService.OrderText(TestText, OrderOption.AlphabeticAsc);

            // Assert
            Assert.AreEqual(result, TestTextOrderedAsc);
        }

        [Test]
        public void OrderTextLenghtAsc()
        {
            // Act
            string result = _textProcessService.OrderText(TestText, OrderOption.LenghtAsc);

            // Assert
            Assert.AreEqual(result, TestTextOrderedLenghtAsc);
        }

        [Test]
        public void GenerateStatistics()
        {
            // Act
            TextStatistics result = _textProcessService.GenerateStatistics(TestText);

            // Assert
            Assert.IsTrue(result.Equals(TestStatistics));
        }
    }
}