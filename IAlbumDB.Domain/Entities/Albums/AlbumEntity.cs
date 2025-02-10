using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;

namespace IAlbumDB.Domain.Entities.Albums
{
    public class AlbumEntity : BaseEntity
    {
        public int Year { get; set; }
        public IList<SongEntity> Songs { get; set; }
        public ArtistEntity Artist { get; init; }
    }
}
