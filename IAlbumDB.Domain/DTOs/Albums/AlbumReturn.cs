namespace IAlbumDB.Domain.DTOs.Albums
{
    public class AlbumReturn
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Year { get; init; }
        public Guid ArtistId { get; init; }
    }
}
