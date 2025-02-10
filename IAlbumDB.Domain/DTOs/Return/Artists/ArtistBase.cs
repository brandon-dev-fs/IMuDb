namespace IAlbumDB.Domain.DTOs.Return.Artists
{
    public class ArtistBase : BaseReturnDto
    {
        public IList<string>? Members { get; init; }
    }
}
