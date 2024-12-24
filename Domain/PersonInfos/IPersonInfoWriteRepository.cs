using System.Linq.Expressions;

namespace Domain.PersonInfos;

public interface IPersonInfoWriteRepository
{
    Task<PersonInfo> GetAsync(Expression<Func<PersonInfo, bool>> predicate);
    Task<IList<PersonInfo>> GetListAsync(Expression<Func<PersonInfo, bool>> predicate);
    Task InsertAsync(PersonInfo personInfo);
    Task<bool> IsExistsAsync(Expression<Func<PersonInfo, bool>> predicate);
    Task RemoveAsync(PersonInfo personInfo);

    Task SaveEntityChanges();


}
