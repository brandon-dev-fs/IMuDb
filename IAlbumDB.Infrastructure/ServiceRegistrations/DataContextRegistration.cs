using IAlbumDB.Domain.Interfaces.Repositories.Albums;
using IAlbumDB.Domain.Interfaces.Repositories.Artist;
using IAlbumDB.Domain.Interfaces.Repositories.Songs;
using IAlbumDB.Infrastructure.Repositories.Albums;
using IAlbumDB.Infrastructure.Repositories.Artists;
using IAlbumDB.Infrastructure.Repositories.Songs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IAlbumDB.Infrastructure.ServiceRegistrations
{
    public static class DataContextRegistration
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AlbumDBConnectionString"));
            });

            // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services
                .AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IArtistRepository, ArtistRepository>()
                .AddScoped<ISongRepository, SongRepository>();

            return services;
        }
    }
}
