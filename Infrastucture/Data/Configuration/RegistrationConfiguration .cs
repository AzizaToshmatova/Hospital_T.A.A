using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastucture.Data.Configuration
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.Date)
            .IsRequired();

            builder.HasOne(e => e.Doctor)
            .WithMany(er => er.Registrations)
            .HasForeignKey(e => e.DoctorId);

            builder.HasOne(e => e.Patient)
                .WithMany(er => er.Registrations)
                .HasForeignKey(e => e.PatientId);

            builder.HasOne(e => e.Admin)
            .WithMany(er => er.Registrations)
            .HasForeignKey(e => e.AdminId);

            builder.HasOne(c => c.Payment);
        }
    }
}
