using Eventos.Data.Db;
using Eventos.Data.Repositorios;
using Eventos.Web.Services;
using Microsoft.EntityFrameworkCore;
using Eventos.Data.Inyecciones;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google; // Este es el using que me faltaba para hacer referencia a la linea 11 
//Si comentan esta linea, el error visto en clase vuelve a aparecer

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Login/Index";
})
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("EventosDb"));
builder.Services.AddScoped<ISumatoriaService, SumatoriaService>();
//builder.Services.AddDbContext<EventosContext>(o =>
//               o.UseSqlServer(builder.Configuration.GetConnectionString("EventosDb")));
//builder.Services.AddScoped<IEventoRepository, EventoRepository>();



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

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
