using DickinsonBros.DateTime.Abstractions;
using DickinsonBros.DateTime.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DickinsonBros.DateTime.Tests.Extensions
{
    [TestClass]
    public class IServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void AddDateTimeService_Should_Succeed()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            // Act
            serviceCollection.AddDateTimeService();
            // Assert
            Assert.IsTrue(serviceCollection.Any(serviceDefinition => serviceDefinition.ServiceType == typeof(IDateTimeService) &&
                                                       serviceDefinition.ImplementationType == typeof(DateTimeService) &&
                                                       serviceDefinition.Lifetime == ServiceLifetime.Singleton));
        }
    }
}
