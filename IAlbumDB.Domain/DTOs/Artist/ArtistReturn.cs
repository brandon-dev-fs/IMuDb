namespace IAlbumDB.Domain.DTOs.Artist
{
    public class ArtistReturn
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public IList<string>? Members { get; init; }
    }
}
