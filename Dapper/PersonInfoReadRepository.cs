using Dapper;
using Domain.PersonInfos;
using System.Data;

namespace DapperORM
{
    public class PersonInfoReadRepository : IPersonInfoReadRepository
    {
        private readonly IDbConnection _connection;
        public PersonInfoReadRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<PersonInfo> GetAsync(long id)
        {
            string sql = $"SELECT * FROM PersonInfo WHERE Id = @id";
            var parameters = new { Id = id };
            return await _connection.QueryFirstOrDefaultAsync<PersonInfo>(sql, parameters);

        }

        public async Task<List<PersonInfo>> GetListAsync(string name, string family, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            string sql = "SELECT * FROM PersonInfo WHERE Name=@name and Family=@family and Date >= @StartDate AND Date <= @EndDate";
            var parameters = new { Name = name, Family = family, StartDate = startDate, EndDate = endDate };

            var result = await _connection.QueryAsync<PersonInfo>(sql, parameters);

            return result.ToList();
        }
    }
}
