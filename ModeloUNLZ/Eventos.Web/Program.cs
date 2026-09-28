using Eventos.Data.Db;
using Eventos.Data.Repositorios;
using Eventos.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("EventosDb"));
builder.Services.AddScoped<ISumatoriaService, SumatoriaService>();
builder.Services.AddDbContext<EventosContext>(o =>
               o.UseSqlServer(builder.Configuration.GetConnectionString("EventosDb")));
builder.Services.AddScoped<IEventoRepository, EventoRepository>();



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
