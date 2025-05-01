using Microsoft.EntityFrameworkCore;
using Practica2_JeanEstrada.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext ANTES de builder.Build()
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Resto de servicios
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline (esto está correcto)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ¿Es esto lo que intentabas con MapStaticAssets?
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();