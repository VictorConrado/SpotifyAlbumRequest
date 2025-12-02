using Microsoft.Extensions.Options;
using Refit;
using SpotifyAlbumRequestBackEnd.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Configurações Spotify ---
builder.Services.Configure<SpotifySettings>(builder.Configuration.GetSection("Spotify"));

// --- CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
             "http://localhost:5173",
             "https://spotifyalbumrequestfrontend.onrender.com" 
         )
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


// --- Controllers ---

builder.Services.AddControllers();

// --- Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Porta (Docker) ---
builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// --- MIDDLEWARES IMPORTANTES ---
app.UseStaticFiles(); 
app.UseSwagger();
app.UseSwaggerUI();

var isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
if (!isDocker)
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
