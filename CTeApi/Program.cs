using CTe.Repository;
using CTe.Repository.Interface;
using CTeApi.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMotoristaRepository, MotoristaRepository>();
builder.Services.AddSingleton<ITransportadoraRepository, TransportadoraRepository>();
builder.Services.AddSingleton<ICteRepository, CteRepository>();
builder.Services.AddSingleton<IIcmsRepository, IcmsRepository>();

builder.Services.AddMediatrAssembly();

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
