using CRUD_PacienteAPI.Repository.Interfaces;
using CRUD_PacienteAPI.Repository;
using CRUD_PacienteAPI.Services;
using Microsoft.EntityFrameworkCore;
using CRUD_PacienteAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<PatientRepository>();

builder.Services.AddDbContext<PatientContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
});

builder.WebHost.ConfigureServices(services =>
{
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    services.AddControllers();
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
