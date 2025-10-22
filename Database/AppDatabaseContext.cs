using ApiEscala.Modules.Member;
using ApiEscala.Modules.Ministry;
using ApiEscala.Modules.Schedule;
using ApiEscala.Modules.Users;
using ApiEscala.Utils;
using Microsoft.EntityFrameworkCore;

namespace ApiEscala.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MemberModel> Members => Set<MemberModel>();
    public DbSet<UserModel> Users => Set<UserModel>();

    public DbSet<MinistryModel> Ministries => Set<MinistryModel>();
    public DbSet<ScheduleModel> Schedules => Set<ScheduleModel>();

    public DbSet<ScheduleMember> ScheduleMember => Set<ScheduleMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            IEnumerable<System.Reflection.PropertyInfo> properties = entityType
                .ClrType.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(UniqueAttribute)));

            foreach (var property in properties)
            {
                modelBuilder.Entity(entityType.Name).HasIndex(property.Name).IsUnique();
            }
            modelBuilder
                .Entity<ScheduleMember>()
                .HasOne(sm => sm.Schedule)
                .WithMany(s => s.Members)
                .HasForeignKey(sm => sm.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        base.OnModelCreating(modelBuilder);
    }
}
