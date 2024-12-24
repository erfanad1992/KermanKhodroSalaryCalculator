using Domain.Interfaces;
using IdGen;
using Microsoft.Extensions.DependencyInjection;

namespace SnowFlakeLongIdGenerator;
public static class ApplicationServiceCollectionExtensions
{
    public static void AddIdGeneratorServices(this IServiceCollection services)
    {
        services.AddSingleton<IIdGenerator, SnowflakeIdGenerator>();

        services.AddSingleton(sp =>
        {
            var options = new IdGeneratorOptions(sequenceOverflowStrategy: SequenceOverflowStrategy.SpinWait);
            int maxNumber = 1 << options.IdStructure.GeneratorIdBits;
            var workerId = new Random().Next(maxNumber + 1);
            return new IdGenerator(workerId, options);
        });
    }
}