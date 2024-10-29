using IAlbumDB.Domain.Interfaces.Services.Album;
using IAlbumDB.Domain.Interfaces.Services.Artist;
using IAlbumDB.Domain.Interfaces.Services.Song;
using IAlbumDB.Infrastructure.Services.Album;
using IAlbumDB.Infrastructure.Services.Artist;
using IAlbumDB.Infrastructure.Services.Song;
using Microsoft.Extensions.DependencyInjection;

namespace IAlbumDB.Infrastructure.Services.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IAlbumService, AlbumServices>()
                .AddScoped<IArtistService, ArtistServices>()
                .AddScoped<ISongService, SongServices>();
            return services;
        }
    }
}
