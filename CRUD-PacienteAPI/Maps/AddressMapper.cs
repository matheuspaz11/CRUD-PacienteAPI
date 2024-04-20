using CRUD_PacienteAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_PacienteAPI.Maps
{
    public class AddressMapper : BaseMapper<Address>
    {
        public AddressMapper() : base("tb_address") { }

        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Street).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Neighborhood).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.HouseNumber).IsRequired();
            builder.Property(x => x.City).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.State).HasColumnType("varchar(2)").IsRequired();

            builder.Property(x => x.PatientId).HasColumnName("id_patient").IsRequired();
            builder.HasOne(x => x.Patient).WithOne(x => x.Address).HasForeignKey<Address>(x => x. PatientId);
        }
    }
}