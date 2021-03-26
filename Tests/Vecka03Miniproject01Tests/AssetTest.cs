using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Xunit;

namespace Vecka03Miniproject01Tests
{
    public class AssetTest
    {
        [Fact]
        public void StatusValid()
        {
            //-- Arrange
            var asset = new Asset();
            AssetStatus expected = AssetStatus.New;
            //-- Act
            AssetStatus actual = asset.Status;
            //-- Assert
            Assert.Equal(expected, actual);
        }
        
    }
}
