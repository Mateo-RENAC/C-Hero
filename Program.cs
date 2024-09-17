using C_Hero.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using C_Hero.Models.Entities;
using C_Hero.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


// Register services
builder.Services.AddScoped<ICivilService, CivilService>();
builder.Services.AddScoped<IOrgaService, OrgaService>();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<ISuperVillainService, SuperVillainService>();
builder.Services.AddScoped<IIncidentService, IncidentService>();
builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<ICrisisService, CrisisService>();
builder.Services.AddScoped<IDisputeService, DisputeService>();
builder.Services.AddScoped<IRapportService, RapportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
