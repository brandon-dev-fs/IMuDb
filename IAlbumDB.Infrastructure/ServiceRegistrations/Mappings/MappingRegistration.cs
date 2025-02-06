using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;
using IAlbumDB.Infrastructure.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace IAlbumDB.Infrastructure.ServiceRegistrations.Mappings
{
    public static class MappingRegistration
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services
                .AddScoped<IMapping<AlbumCreate, AlbumEntity>, AutoMapping<AlbumCreate, AlbumEntity>>()
                .AddScoped<IMapping<AlbumDetails, AlbumEntity>, AutoMapping<AlbumDetails, AlbumEntity>>()
                .AddScoped<IMapping<AlbumReturn, AlbumEntity>, AutoMapping<AlbumReturn, AlbumEntity>>()
                .AddScoped<IMapping<ArtistCU, ArtistEntity>, AutoMapping<ArtistCU, ArtistEntity>>()
                .AddScoped<IMapping<ArtistDetails, ArtistEntity>, AutoMapping<ArtistDetails, ArtistEntity>>()
                .AddScoped<IMapping<ArtistReturn, ArtistEntity>, AutoMapping<ArtistReturn, ArtistEntity>>()
                .AddScoped<IMapping<SongCreate, SongEntity>, AutoMapping<SongCreate, SongEntity>>()
                .AddScoped<IMapping<SongDetails, SongEntity>, AutoMapping<SongDetails, SongEntity>>()
                .AddScoped<IMapping<SongReturn, SongEntity>, AutoMapping<SongReturn, SongEntity>>();
            return services;
        }
    }
}
