using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit.Application.Services
{
    public class NewServiceTest
    {
        [Fact]
        public void CreateProvinceFromNameReturnsProvince()
        {
            // Arrange
            var provinceName = "Madrid";
            ProvinceService sut = new ProvinceService();

            // Act
            Province p = sut.CreateProvince(provinceName);

            // Assert
            Assert.Equal(p.Name, provinceName);
        }

        [Fact]
        public void CreateProvinceFromEmptyNameThrowsException()
        {
            // Arrange
            var provinceName = string.Empty;
            ProvinceService sut = new ProvinceService();

            // Act
            Action action = () => sut.CreateProvince(provinceName);

            // Assert
            Assert.Throws<Exception>(action);
        }
    }
}
