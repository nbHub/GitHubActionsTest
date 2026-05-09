using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using MyWebAPI;
using MyWebAPI.Controllers;

namespace MyApi.UnitTests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Get_ReturnsFiveForecasts()
        {
            // 1. Arrange
            // We mock the logger because the controller requires it in the constructor
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(mockLogger.Object);

            // 2. Act
            var result = controller.Get();

            // 3. Assert
            var forecasts = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(5, forecasts.Count());
        }
    }
}