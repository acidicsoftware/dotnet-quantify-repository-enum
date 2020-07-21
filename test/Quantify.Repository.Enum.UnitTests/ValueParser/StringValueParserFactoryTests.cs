﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantify.Repository.Enum.Test.Assets;
using Quantify.Repository.Enum.ValueParser;

namespace Quantify.Repository.Enum.UnitTests.ValueParser
{
    [TestClass]
    public class StringValueParserFactoryTests
    {
        [TestMethod]
        public void WHILE_ArgumentTypeDouble_WHEN_BuildingValueParser_THEN_ReturnDoubleStringValueParser()
        {
            // Arrange
            var stringValueParserFactory = new StringValueParserFactory();

            // Act
            var stringValueParser = stringValueParserFactory.Build<double>();

            // Assert
            Assert.IsInstanceOfType(stringValueParser, typeof(StringToDoubleValueParser));
        }

        [TestMethod]
        public void WHILE_ArgumentTypeDecimal_WHEN_BuildingValueParser_THEN_ReturnDecimalStringValueParser()
        {
            // Arrange
            var stringValueParserFactory = new StringValueParserFactory();

            // Act
            var stringValueParser = stringValueParserFactory.Build<decimal>();

            // Assert
            Assert.IsInstanceOfType(stringValueParser, typeof(StringToDecimalValueParser));
        }

        [TestMethod]
        public void WHILE_InvalidArgumentType_WHEN_BuildingValueParser_THEN_ThrowException()
        {
            // Arrange
            var stringValueParserFactory = new StringValueParserFactory();

            ExceptionHelpers.ExpectException<GenericArgumentException>(
                // Act
                () => stringValueParserFactory.Build<string>(),
                // Assert
                (exception) =>
                {
                    Assert.AreEqual("TValue", exception.ArgumentName);
                    Assert.AreEqual(typeof(string), exception.ArgumentType);
                }
            );
        }
    }
}