using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Infrastructure.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddDbContext<VehicleTollContext>(optionsBuilder => optionsBuilder.UseSqlite());
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<VehicleTollContext>();
    await context.Database.MigrateAsync();

    int a = 0;
    a++;
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
