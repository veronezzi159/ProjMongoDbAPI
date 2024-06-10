using Microsoft.Extensions.Options;
using ProjMongoDbAPI.Services;
using ProjMongoDbAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Utilizar o Arquivo de configuração

builder.Services.AddControllers();

builder.Services.Configure<ProjMongoDbAPIDataBaseSettings>(
               builder.Configuration.GetSection(nameof(ProjMongoDbAPIDataBaseSettings)));

builder.Services.AddSingleton<IProjMongoDbAPIDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ProjMongoDbAPIDataBaseSettings>>().Value);

builder.Services.AddSingleton<CostumerService>();
builder.Services.AddSingleton<AddressService>();

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
