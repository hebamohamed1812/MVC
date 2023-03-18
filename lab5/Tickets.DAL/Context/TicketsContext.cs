using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Tickets.DAL;

public class TicketsContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Developer> Developers => Set<Developer>();

    public TicketsContext(DbContextOptions<TicketsContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":1,"Title":"Dana","DepartmentId":1},{"Id":2,"Title":"Isaac","DepartmentId":2},{"Id":3,"Title":"Damon","DepartmentId":1},{"Id":4,"Title":"Miriam","DepartmentId":3},{"Id":5,"Title":"Terence","DepartmentId":4}]""") ?? new();
        var departments = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Jessie"},{"Id":2,"Name":"heba"},{"Id":3,"Name":"alaa"},{"Id":4,"Name":"noor"},{"Id":5,"Name":"yas"}]""") ?? new();
        var developers = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Diabetes"},{"Id":2,"Name":"Hypertension"},{"Id":3,"Name":"Asthma"},{"Id":4,"Name":"Depression"},{"Id":5,"Name":"Arthritis"}]""") ?? new();

        modelBuilder.Entity<Ticket>().HasData(tickets);
        modelBuilder.Entity<Department>().HasData(departments);
        modelBuilder.Entity<Developer>().HasData(developers);
    }
}