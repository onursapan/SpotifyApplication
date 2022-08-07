using Microsoft.Extensions.DependencyInjection;
using SpotifyApplication.Services.Albums.Interfaces;

namespace SpotifyApplication.Test
{
    public class AlbumTest :  IClassFixture<TestStartUp>
    {
        private readonly ServiceProvider _serviceProvider;

        public AlbumTest(TestStartUp testStartUp)
        {
            _serviceProvider = testStartUp.ServiceProvider;
        }
       
        [Fact] //Parametre Metodlar Ýçin 
        public async void GetAlbumListTest()
        {
            var service =  _serviceProvider.GetRequiredService<IAlbumService>();
            await service.GetAlbumList();
        }
    }
}