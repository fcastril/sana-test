using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Common.Constants;

namespace Sana.Backend.Infrastructure.SQLServer.Configurations
{
    public class BaseConfiguration<T> where T : BaseEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name, SQLServerConstants.DefaultSchema);

            builder.HasKey(x => x.Id);


        }
    }
}
