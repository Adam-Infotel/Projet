using Microsoft.EntityFrameworkCore;
using BackEnd.Context;
using BackEnd.Services;
using System.Text;
using BackEnd.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Ajouter la configuration de la chaîne de connexion à la base de données PostgreSQL (si vous utilisez PostgreSQL)
builder.Services.AddDbContext<MonProjetDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajouter les services nécessaires pour l'API (contrôleurs)
builder.Services.AddControllers();

// Ajoutez Swagger pour faciliter le test de l'API en développement
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Ajouter le repository et le service à l'injection de dépendances
builder.Services.AddScoped<IPersonneRepository, PersonneRepository>();
builder.Services.AddScoped<IPersonneService, PersonneService>();

// Configuration CORS (permettre les requêtes depuis l'application frontend Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:4200")  // Permet uniquement l'URL de votre frontend
            .AllowAnyMethod()                      // Permet toutes les méthodes HTTP (GET, POST, etc.)
            .AllowAnyHeader());                    // Permet tous les en-têtes
});

var app = builder.Build();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],  
            ValidAudience = builder.Configuration["Jwt:Audience"],  
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))  
        };
    });
// Activer Swagger uniquement en mode développement pour faciliter le test de l'API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ajouter le middleware CORS avant les autres middlewares
app.UseCors("AllowFrontend"); // Applique la politique CORS "AllowFrontend"

app.UseRouting();

// Ajouter les contrôleurs à l'API
app.MapControllers();

// Lancer l'application
app.Run();
