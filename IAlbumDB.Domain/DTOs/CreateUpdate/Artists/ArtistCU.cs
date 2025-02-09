namespace IAlbumDB.Domain.DTOs.CreateUpdate.Artists
{
    public class ArtistCU
    {
        public string Name { get; init; }
        public IList<string>? Members { get; init; }
    }
}
