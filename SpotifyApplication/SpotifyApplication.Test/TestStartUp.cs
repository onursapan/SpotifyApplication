
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotifyApplication.Repositories.Albums.Implementations;
using SpotifyApplication.Repositories.Albums.Interfaces;
using SpotifyApplication.Services.Albums.Implementations;
using SpotifyApplication.Services.Albums.Interfaces;
using SpotifyApplication.Services.Artists.Implementations;
using SpotifyApplication.Services.Artists.Interfaces;
using System;

namespace SpotifyApplication.Test
{
    public class TestStartUp
    {
        public TestStartUp()
        {
            var workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            const string environmentSpecificFileName = "appsettings.json";
            var configPath = $"{workingDirectory}/{environmentSpecificFileName}";
            var builder = new ConfigurationBuilder()
                .AddJsonFile(configPath, true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();


            ServiceProvider = services.AddLogging().BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; set; }

        public IConfigurationRoot Configuration { get; set; }
    }
}
