using ContactBook_Application.MapInitializer;
using ContactBook_Application.Service.Abstraction;
using ContactBook_Application.Service.Implementation;
using ContactBook_Infrastructure.Persistence;
using ContactBookApp.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using IAuthenticationService = ContactBook_Application.Service.Abstraction.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.ConfigureDataBaseContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MapInitializer));
builder.Services.ResolveDependencyInjection();
builder.Services.ConfigureImageService();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSwaggerAuth();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
