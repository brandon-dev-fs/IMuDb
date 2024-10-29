using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;
using Microsoft.EntityFrameworkCore;

namespace IAlbumDB.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<SongEntity> Songs { get; set; }
    }
}
