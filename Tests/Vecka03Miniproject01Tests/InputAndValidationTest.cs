using System;
using Vecka03Miniproject01;
using Xunit;

namespace Vecka03Miniproject01Tests
{
    public class InputAndValidationTest
    {
        [Fact]
        public void ReadAndValidateValid()
        {
            //-- Arrange
            InputAndValidation.ReadAndValidate(out Location output, "Enter your location");
            Location expected = Location.Sweden;
            //-- Act
            Location actual = output;
            //-- Assert
            Assert.Equal(expected, actual);
        }
    }
}
