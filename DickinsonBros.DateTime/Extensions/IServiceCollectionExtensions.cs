using DickinsonBros.DateTime.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DickinsonBros.DateTime.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDateTimeService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IDateTimeService, DateTimeService>();
            return serviceCollection;
        }
    }
}
