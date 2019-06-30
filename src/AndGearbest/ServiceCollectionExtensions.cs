using Microsoft.Extensions.DependencyInjection;

namespace AndGearbest
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGearbestApi(this IServiceCollection serviceCollection, string apiKey, string secretKey, string lkid = null)
        {
            serviceCollection.AddSingleton<IGearbestApi>(new GearbestApi(apiKey, secretKey, lkid));
        }
    }
}