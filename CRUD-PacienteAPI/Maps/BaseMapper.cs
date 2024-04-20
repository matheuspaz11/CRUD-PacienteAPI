using CRUD_PacienteAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_PacienteAPI.Maps
{
    public class BaseMapper<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        private readonly string _tableName;

        public BaseMapper(string tableName)
        {
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tableName))
                builder.ToTable(_tableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}
