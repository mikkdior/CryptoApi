using CryptoApi.Api;
using CryptoApi.Models.DB;
using CryptoApi.Services;
using CryptoApi.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CDbM>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
, ServiceLifetime.Singleton);

builder.Services.AddTransient<CCommonM>();
builder.Services.AddTransient<CCoinsM>();
builder.Services.AddTransient<CCoinPairsM>();

builder.Services.AddTransient<CBlocksHelperVM>();
builder.Services.AddTransient<CCoinsVM>();
builder.Services.AddTransient<CCoinVM>();
builder.Services.AddTransient<CCoinPairsVM>();
builder.Services.AddTransient<CCoinPairVM>();
builder.Services.AddTransient<CHomeVM>();

builder.Services.AddTransient<CActualizerM>();
builder.Services.AddSingleton<CApiManager>();
builder.Services.AddSingleton<IRunnerM, CRunnerM>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
