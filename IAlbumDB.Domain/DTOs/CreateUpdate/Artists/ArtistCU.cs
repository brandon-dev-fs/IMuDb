using IAlbumDB.Domain.Entities.Artists;

namespace IAlbumDB.Domain.DTOs.CreateUpdate.Artists
{
    public class ArtistCU
    {
        public string Name { get; init; }
        public IList<string>? Musicians { get; init; }
        public ArtistType Type { get; init; }
    }
}
