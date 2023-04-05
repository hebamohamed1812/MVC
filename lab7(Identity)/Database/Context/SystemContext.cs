using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab7_Identity_.Database;

public class SystemContext : IdentityDbContext<Student>
{
    public SystemContext(DbContextOptions<SystemContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Student>().ToTable("Students");
    }
}
