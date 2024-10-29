using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;

namespace IAlbumDB.Domain.Entities.Albums
{
    public class AlbumEntity : BaseEntity
    {
        public int Year { get; set; }
        public List<SongEntity> Songs { get; set; } = new();
        public ArtistEntity Artist { get; set; }
        public Guid ArtistId { get; set; }
    }
}
