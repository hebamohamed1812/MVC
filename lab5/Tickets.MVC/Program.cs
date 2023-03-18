using Microsoft.EntityFrameworkCore;
using Tickets;
using Tickets.BL;
using Tickets.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("TicketsSystem");
builder.Services.AddDbContext<TicketsContext>(options
    => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITicketsManager, TicketsManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();

builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<DepartmentsRepo, DepartmentsRepo>();
builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
