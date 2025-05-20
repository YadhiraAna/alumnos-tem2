using ControlEscolarCore.Controller;
using ControlEscolarCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexi�n para PostgreSQLDataAccess
PostgreSQLDataAccess.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar para usar el puerto asignado por Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregamos el controller de Estudiantes
builder.Services.AddScoped<EstudiantesController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
