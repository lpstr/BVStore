using BVStore.API;
using BVStore.API.Services;
using BVStore.Domain.Contracts;
using BVStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


//Add DbContext
builder.Services.AddDbContext<BVStoreDbContext>(options => 
        options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(BVStoreDbContext).Assembly.FullName)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

app.MigrateDatabase();
app.SeedDatabase();
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
