namespace Domain.PersonInfos
{
    public interface IPersonInfoReadRepository
    {
        Task<PersonInfo> GetAsync(long id);
        Task<List<PersonInfo>> GetListAsync(string name, string family, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
