using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.DTOs.Albums
{
    public class AlbumCreate
    {
        public string Name { get; init; }
        public int Year { get; init; }
        public Guid ArtistId { get; init; }
        public IList<SongCreate> Songs { get; init; }
    }
}
