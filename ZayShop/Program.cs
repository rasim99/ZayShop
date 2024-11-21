using Microsoft.EntityFrameworkCore;
using ZayShop.Data;
using ZayShop.Utilities.File;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>( opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")) );
builder.Services.AddSingleton<IFileService,FileService>();

var app = builder.Build();
app.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
  );
app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.Run();
