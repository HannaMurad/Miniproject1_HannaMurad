using System;
using System.Collections.Generic;
using System.Linq;
using Vecka03Miniproject01;
using Xunit;

namespace Vecka03Miniproject01Tests
{
    public class OfficeTest
    {
        [Fact]
        public void CurrencyValid()
        {
            //-- Arrange
            var office = new Office(Location.Sweden);
            string expected = "sek";
            //-- Act
            string actual = office.Currency;
            //-- Assert
            Assert.Equal(expected, actual);
        }

    }
}
