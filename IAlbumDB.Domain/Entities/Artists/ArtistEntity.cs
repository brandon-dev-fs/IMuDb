using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Songs;

namespace IAlbumDB.Domain.Entities.Artists
{
    public class ArtistEntity : BaseEntity
    {
        public List<string>? Members { get; set; }
        public List<AlbumEntity> Albums { get; set; } = new();
        public List<SongEntity> Songs { get; set; } = new();
    }
}
