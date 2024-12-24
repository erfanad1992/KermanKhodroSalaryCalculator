using KermanKhodro.Infrastructure.EfPersistance.Extensions;
using KermanKhodro.Application.Extensions;
using KermanKhodro.DapperORM.Extensions;
using SnowFlakeLongIdGenerator;
namespace WebApi.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddPersistenceEntityFrameworkServices(configuration);
            services.AddApplicationServices();
            services.AddDapperServices(configuration);
            services.AddIdGeneratorServices();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddMvc();

            return services;
        }
    }
}
