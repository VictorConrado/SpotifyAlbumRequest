using Microsoft.Extensions.Options;
using Refit;
using SpotifyAlbumRequestBackEnd.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Carrega configurações (Spotify: ClientId / ClientSecret) ---
var configuration = builder.Configuration;
builder.Services.Configure<SpotifySettings>(configuration.GetSection("Spotify"));

// --- CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// --- Refit Clients ---
builder.Services
    .AddRefitClient<IAuthSpotifyClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://accounts.spotify.com");
    });

builder.Services
    .AddRefitClient<IAlbumSpotifyClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://api.spotify.com");
    });

builder.Services
    .AddRefitClient<IGoogleClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://google.com");
    });

// --- Controllers ---
builder.Services.AddControllers();

// --- Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- Swagger UI (somente em Dev) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
