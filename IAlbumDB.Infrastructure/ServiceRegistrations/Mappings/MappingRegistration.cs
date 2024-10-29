using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;
using IAlbumDB.Infrastructure.Mappers.Album;
using IAlbumDB.Infrastructure.Mappers.Artist;
using IAlbumDB.Infrastructure.Mappers.Song;
using Microsoft.Extensions.DependencyInjection;

namespace IAlbumDB.Infrastructure.ServiceRegistrations.Mappings
{
    public static class MappingRegistration
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services
                .AddScoped<IMapping<AlbumCreateDto, AlbumEntity>, AlbumCreateMappings>()
                .AddScoped<IMapping<AlbumDetailsDto, AlbumEntity>, AlbumDetailsMappings>()
                .AddScoped<IMapping<AlbumReturnDto, AlbumEntity>, AlbumReturnMappings>()
                .AddScoped<IMapping<ArtistCreateDto, ArtistEntity>, ArtistCreateMappings>()
                .AddScoped<IMapping<ArtistDetailsDto, ArtistEntity>, ArtistDetailsMappings>()
                .AddScoped<IMapping<ArtistReturnDto, ArtistEntity>, ArtistReturnMappings>()
                .AddScoped<IMapping<SongCreateDto, SongEntity>, SongCreateMappings>()
                .AddScoped<IMapping<SongDetailsDto, SongEntity>, SongDetailsMappings>()
                .AddScoped<IMapping<SongReturnDto, SongEntity>, SongReturnMappings>();
            return services;
        }
    }
}
