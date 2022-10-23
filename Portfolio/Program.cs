using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
 
/*
 3 TIPOS DE SERVICIOS:
AddTransient
AddScoped
AddSingleton

 AddTransient: son servicios que viven por menos tiempo. Cada vez que se inyecta en una clase, se nos serviria una nueva instancia del servicio.
 AddScoped: Definir como limitado. tiempo de vida es delimitado por una peticion http. Dentro de la misma peticion htpp se nos brinda la misma instancia del servicio. Sin embargo, en distintas peticiones http se nos brinda distintas instancias.
 AddSingleton: Servicio que mas tiempo dura, incluso, para siempre. Se renueva solamente si la app se reinicia. Siempre se nos brinda la misma instancia del servicio, incluso en peticiones http distintas.
 */
 
builder.Services.AddTransient<IRepositoryProjects, RepositoryProjects>();
builder.Services.AddTransient<ServicioTransitorio>();
builder.Services.AddScoped<ServicioDelimitado>();
builder.Services.AddSingleton<ServicioUnico>();

builder.Services.AddTransient<IServicioEmail, ServicioEmailSendGrid>();

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
