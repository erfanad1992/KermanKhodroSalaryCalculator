using Domain.PersonInfos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KermanKhodro.Infrastructure.EfPersistance.PersonInfos
{
    public class PersonInfoWriteRepository : IPersonInfoWriteRepository
    {
        protected DbContext Context;
        protected DbSet<PersonInfo> DbSet;

        public PersonInfoWriteRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<PersonInfo>();
        }

        public async Task<PersonInfo> GetAsync(Expression<Func<PersonInfo, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);

        }

        public async Task<IList<PersonInfo>> GetListAsync(Expression<Func<PersonInfo, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task InsertAsync(PersonInfo personInfo)
        {
            await DbSet.AddAsync(personInfo);
            await SaveEntityChanges();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<PersonInfo, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task Remove(PersonInfo personInfo)
        {
            DbSet.Remove(personInfo);
            await SaveEntityChanges();
        }

        public async Task SaveEntityChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
