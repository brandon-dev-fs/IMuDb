using IAlbumDB.Domain.DTOs.CreateUpdate.Albums;
using IAlbumDB.Domain.DTOs.CreateUpdate.Artists;
using IAlbumDB.Domain.DTOs.CreateUpdate.Songs;
using IAlbumDB.Domain.DTOs.Return.Albums;
using IAlbumDB.Domain.DTOs.Return.Artists;
using IAlbumDB.Domain.DTOs.Return.Songs;
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
                .AddScoped<IMapping<AlbumCU, AlbumEntity>, AutoMapping<AlbumCU, AlbumEntity>>()
                .AddScoped<IMapping<AlbumDetails, AlbumEntity>, AutoMapping<AlbumDetails, AlbumEntity>>()
                .AddScoped<IMapping<AlbumBase, AlbumEntity>, AutoMapping<AlbumBase, AlbumEntity>>()
                .AddScoped<IMapping<ArtistCU, ArtistEntity>, AutoMapping<ArtistCU, ArtistEntity>>()
                .AddScoped<IMapping<ArtistDetails, ArtistEntity>, AutoMapping<ArtistDetails, ArtistEntity>>()
                .AddScoped<IMapping<ArtistBase, ArtistEntity>, AutoMapping<ArtistBase, ArtistEntity>>()
                .AddScoped<IMapping<SongCU, SongEntity>, AutoMapping<SongCU, SongEntity>>()
                .AddScoped<IMapping<SongDetails, SongEntity>, AutoMapping<SongDetails, SongEntity>>()
                .AddScoped<IMapping<SongBase, SongEntity>, AutoMapping<SongBase, SongEntity>>();
            return services;
        }
    }
}
