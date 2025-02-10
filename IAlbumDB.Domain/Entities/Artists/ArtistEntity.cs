using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Songs;

namespace IAlbumDB.Domain.Entities.Artists
{
    public class ArtistEntity : BaseEntity
    {
        public IList<string>? Musicians { get; set; }
        public IList<AlbumEntity>? Albums { get; set; }
        public IList<SongEntity>? Songs { get; set; }
    }
}
