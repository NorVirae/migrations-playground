using FluentMigrator.Runner;
using MigrationsPlayGround.Context;
using MigrationsPlayGround.Extensions;
using MigrationsPlayGround.Mirgations;
using System.Reflection;
using FluentMigrator.Postgres;


var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .Build();
// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Database>();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddPostgres11_0()
            .WithGlobalConnectionString(Configuration.GetConnectionString("SqlConnection"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MigrateDatabase();

app.UseAuthorization();

app.MapControllers();

app.Run();
