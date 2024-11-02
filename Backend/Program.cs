using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Backend.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// inyeccion de dependencias:
//builder.Services.AddSingleton<IPeopleService, People2Service>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");
builder.Services.AddKeyedSingleton<IPeopleService, People2Service>("people2Service");

// TIPOS DE INYECCIONES
//-------------------------------<Interfaz, implementacion>(key)
// singleton
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");
// Scoped
builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");
// Transient
builder.Services.AddKeyedTransient<IRandomService, RandomService>("randonTransient");

// inyectamos nuestro servicio jsonplaceholder
builder.Services.AddScoped<IPostsService, PostsService>();
// Inyectamos servicio cerveza
builder.Services.AddScoped<IBeerService, BeerService>();

// y luego inyectamos el httpclient, interface que lo va a usar, luego la implementacion
builder.Services.AddHttpClient<IPostsService, PostsService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
}
);


// Entity Framework -> git sinyectamos el contexto 
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection")
);

});

// validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();



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

app.MapControllers();

app.Run();
