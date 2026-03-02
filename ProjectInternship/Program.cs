using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using ProjectInternship.Data;
using ProjectInternship.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PlannedTransactionDbContext>(options =>
//options.UseOracle(
//    builder.Configuration.GetConnectionString("OracleDb")));
options.UseInMemoryDatabase("TestDB"));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<PlannedTransactionService>();
builder.Services.AddScoped<PlannedTransactionRegistrationService>();
builder.Services.AddScoped<PlanTransactionDetailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
