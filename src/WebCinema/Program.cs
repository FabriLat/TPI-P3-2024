using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Application.Interfaces;
using Infrastructure.Data.Repositories;
using Application.Services;
using Infrastructure.Servicies;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
setupAction.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
{
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    Description = "Acá pegar el token generado al loguearse."
});

setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
});

//Inyeccion de contexto
var connectionString = builder.Configuration.GetConnectionString("CinemaProjectDBConnectionString");
var connection = new SqliteConnection(connectionString);

//Inyeccion de repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IClientShowRepository, ClientShowRepository>();

//Inyeccion de servicios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>(); 
builder.Services.AddScoped<IMovieService, MovieService>();

connection.Open();

using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(connection));

builder.Services.AddAuthentication("Bearer") 
    .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);

builder.Services.AddAuthorization(options => //valida que el usuario logueado sea admin
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type.Contains("role") && c.Value == "Admin")));
});



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
