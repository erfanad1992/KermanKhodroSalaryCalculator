using Domain.PersonInfos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KermanKhodro.Infrastructure.EfPersistance.PersonInfos
{
    public class PersonInfoEntityConfiguration : IEntityTypeConfiguration<PersonInfo>
    {
        public void Configure(EntityTypeBuilder<PersonInfo> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name);

            builder.ToTable(nameof(PersonInfo));
        }
    }
}
