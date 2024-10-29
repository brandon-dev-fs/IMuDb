using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.DTOs.Albums
{
    public class AlbumCreateDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Guid ArtistId { get; set; }
        public IList<SongCreateDto> Songs { get; set; }
    }
}
