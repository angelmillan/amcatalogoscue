using AMCatalogosCUE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AmsystemRegistroCueContext>(options =>
{ 
    options.UseSqlServer(builder.Configuration["ConnectionString"], sqlServerOptionsAction: sqlOptions => {
       
        sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);

        //Configuring Connection Resiliency:
        sqlOptions.
            EnableRetryOnFailure(maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
        
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AM System Catalalogos SIEX CUE REA",
        Description = "Catalogo de registros maestros unificados para Cuadernos de Campo Europeo CUE y Registro de  Actividades Agrarias REA",
        
        TermsOfService = new Uri("https://alosuite.com"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://alosuite.com")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://alosuite.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

