using SpotifyApplication.Repositories.Albums.Implementations;
using SpotifyApplication.Repositories.Albums.Interfaces;
using SpotifyApplication.Repositories.Artists.Implementations;
using SpotifyApplication.Repositories.Artists.Interfaces;
using SpotifyApplication.Services.Albums.Implementations;
using SpotifyApplication.Services.Albums.Interfaces;
using SpotifyApplication.Services.Artists.Implementations;
using SpotifyApplication.Services.Artists.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();

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

