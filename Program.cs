using HermanosK.DAL;
using HermanosK.Domain.Interfaces;
using HermanosK.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios antes de construir la aplicaci�n


// Aseg�rate de agregar las dependencias necesarias
builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IComentarioService, ComentarioService>();

builder.Services.AddTransient<SeederDB>();

builder.Services.AddControllersWithViews();

var app = builder.Build(); // Aqu� se construye la aplicaci�n

// Configura el middleware de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//Mapea las rutas de los controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Comentarios}/{action=Listar}/{id?}");

//app.Run();
