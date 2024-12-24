using Domain.Interfaces;
using IdGen;

namespace SnowFlakeLongIdGenerator;

internal class SnowflakeIdGenerator : IIdGenerator
{
    private readonly IdGenerator _idGenerator;

    public SnowflakeIdGenerator(IdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    public long GetNewId()
    {
        return _idGenerator.CreateId();
    }
}