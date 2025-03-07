﻿using IAlbumDB.Domain.Entities.Artists;

namespace IAlbumDB.Domain.Interfaces.Repositories.Artist
{
    public interface IArtistRepository : IGenericRepository<ArtistEntity>
    {
        Task<IList<ArtistEntity>?> GetAllArtistAsync();
        Task<ArtistEntity?> GetArtistByIdAsync(Guid Id);
        Task<ArtistEntity?> FindArtistByNameAsync(string name);
    }
}
