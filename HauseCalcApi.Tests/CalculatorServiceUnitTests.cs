using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HauseCalcApi.Core;
using HauseCalcApi.Models;

namespace PolistirolbetonDomCalc.Tests
{
    public class CalculatorServiceUnitTests
    {
        [Fact]
        public async Task PriceRepositoryCalledOnce()
        {
            // Arrange
            int areaHouseSquarMeters = 100;

            var repositoryMock = new Mock<IPriceRepository>();    // <--  Task<int> GetPriceByIdAsync(int id);
            var calculatorService = new CalculatorService(repositoryMock.Object);   // <--      тут у нас пустой контракт от  IPriceRepository с методом: Task<int> GetPriceByIdAsync(int id);   и все, без реализации PriceRepository

            // Act
            await calculatorService.GetProjectsCost(areaHouseSquarMeters);   // <--  тут мы просто вызываем метод в заглушку интерфеса, что бы метод запустился и мы могли поймать момент сосединения

            // Assert
            repositoryMock.Verify(r => r.GetPriceByIdAsync(2), Times.Once);
        }
    }

}
