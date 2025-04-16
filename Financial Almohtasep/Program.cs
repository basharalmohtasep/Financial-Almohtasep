global using Financial_Almohtasep.Models;
using Financial_Almohtasep.Data;
using Financial_Almohtasep.HostedServices;
using Financial_Almohtasep.Services.ClinetServices;
using Financial_Almohtasep.Services.ClinetServices.ClinetTransactionServices;
using Financial_Almohtasep.Services.EmployeeServices;
using Financial_Almohtasep.Services.EmployeeServices.TransactionServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHostedService<SalaryHostedService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeTransactionServices, EmployeeTransactionServices>();
builder.Services.AddScoped<IClinetService, ClinetService>();
builder.Services.AddScoped<IClinetTransactionService, ClinetTransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
