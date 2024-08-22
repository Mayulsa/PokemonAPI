using Microsoft.EntityFrameworkCore;
using PokemonAPI;
using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
//Add the interfaces and repository
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

//The code is registering the DataContext class as a service in the application's dependency injection container. 
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();


//Nosavemo que es esto ni chagpt no dice pero funciona
if (args.Length == 1 && args[0].ToLower() == "seeddata")
SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
