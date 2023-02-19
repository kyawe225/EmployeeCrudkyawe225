using Employee.DBA;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.File("Logs/log"+DateTime.Now.ToShortDateString().Replace("/","") + ".txt",rollingInterval:RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Information("Hello Server Starting with serilog");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMySqlDbContext(builder.Configuration);
builder.Services.AddMySqlIdentity();


var app = builder.Build();

app.UseSerilogRequestLogging();

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
