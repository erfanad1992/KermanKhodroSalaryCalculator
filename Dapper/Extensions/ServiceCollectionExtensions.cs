using DapperORM;
using Domain.PersonInfos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace KermanKhodro.DapperORM.Extensions
{
    public static class DapperServiceCollectionExtensions
    {
        public static void AddDapperServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(provider =>
            {

                string connectionString = configuration.GetConnectionString("SqlServerConnectionString");
                return new SqlConnection(connectionString);
            });
            services.AddTransient<IPersonInfoReadRepository, PersonInfoReadRepository>();


        }
    }
}
