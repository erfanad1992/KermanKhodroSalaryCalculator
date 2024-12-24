using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KermanKhodro.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, params Assembly[] assembles)
        {
            var assembliesToScan = assembles?.Any() == true
    ? assembles
    : new[] { Assembly.GetExecutingAssembly() };
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblies(assembliesToScan);
            });

        }
    }
}
