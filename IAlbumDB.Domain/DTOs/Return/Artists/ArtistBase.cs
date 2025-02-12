namespace IAlbumDB.Domain.DTOs.Return.Artists
{
    public class ArtistBase : BaseReturnDto
    {
        public IList<string>? Musicians { get; init; }
    }
}
