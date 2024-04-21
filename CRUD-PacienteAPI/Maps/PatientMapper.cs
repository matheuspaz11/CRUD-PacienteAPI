using CRUD_PacienteAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_PacienteAPI.Maps
{
    public class PatientMapper : BaseMapper<Patient>
    {
        public PatientMapper() : base("tb_patient") { }

        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.DateBirth).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.TaxNumber).HasColumnType("varchar(11)").IsRequired();
            builder.Property(x => x.SexualGender).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
