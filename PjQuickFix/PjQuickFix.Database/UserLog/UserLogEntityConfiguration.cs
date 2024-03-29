using PjQuickFix.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PjQuickFix.Database
{
    public sealed class UserLogEntityConfiguration : IEntityTypeConfiguration<UserLogEntity>
    {
        public void Configure(EntityTypeBuilder<UserLogEntity> builder)
        {
            builder.ToTable("UsersLogs", "User");

            builder.HasKey(x => x.UserLogId);

            builder.Property(x => x.UserLogId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LogType).IsRequired();
            builder.Property(x => x.DateTime).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UsersLogs).HasForeignKey(x => x.UserId);
        }
    }
}
