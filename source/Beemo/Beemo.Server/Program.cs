using Beemo.Server.Context;
using Beemo.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionStringEnvironmentVariable = Environment.GetEnvironmentVariable("BEEMO_DB_CONTEXT_CONNECTION");
var connectionString = !string.IsNullOrEmpty(connectionStringEnvironmentVariable) ? connectionStringEnvironmentVariable : throw new ArgumentNullException("Missing database context connection string environment variable");
var allowBeemoClientOrigins = "_allowBeemoClientOrigins";
var beemoClientOriginsEndpoint = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BEEMO_CLIENT_ORIGINS_ENDPOINT")) ? Environment.GetEnvironmentVariable("BEEMO_CLIENT_ORIGINS_ENDPOINT") : throw new ArgumentNullException("Missing beemo client origins endpoint variable");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
              .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowBeemoClientOrigins, policy =>
    {
        policy.WithOrigins(beemoClientOriginsEndpoint ?? "")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

app.UseAuthorization();

app.UseCors(allowBeemoClientOrigins);

app.MapControllers();

app.MapIdentityApi<ApplicationUser>();

app.Run();
