using IAlbumDB.Domain.DTOs.CreateUpdate.Songs;
using IAlbumDB.Domain.DTOs.Return.Artists;

namespace IAlbumDB.Domain.DTOs.CreateUpdate.Albums
{
    public class AlbumCU
    {
        public string Name { get; init; }
        public int Year { get; init; }
        public ArtistBase Artist { get; init; }
        public IList<SongCU> Songs { get; init; }
    }
}
