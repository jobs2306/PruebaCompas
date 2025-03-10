using BackEndCompas.Data;
using BackEndCompas.Services.Interfaces;
using BackEndCompas.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* //No se requiere por el uso de Procedimientos Almacenados
// AppDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

// Registrar servicios personalizados
builder.Services.AddScoped<IProductoService, ProductoService>();

// Agregar controladores
builder.Services.AddControllers();

// Registrar IHttpClientFactory
builder.Services.AddHttpClient(); 

//servicio de autenticación
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "http://localhost:8080/realms/ApiProductosRealm";
    options.Audience = "BackEndCompas";
    options.RequireHttpsMetadata = false; // Solo para desarrollo
});

// Agregar el servicio de autorización 
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors para Angular
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader());

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

