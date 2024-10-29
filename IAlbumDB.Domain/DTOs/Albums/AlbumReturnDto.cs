using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.DTOs.Albums
{
    public class AlbumReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
