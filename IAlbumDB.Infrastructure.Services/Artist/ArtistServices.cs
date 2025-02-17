using IAlbumDB.Domain.DTOs.CreateUpdate.Artists;
using IAlbumDB.Domain.DTOs.Return.Artists;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Interfaces.Repositories.Artist;
using IAlbumDB.Domain.Interfaces.Services.Artist;
using IAlbumDB.Infrastructure.Extensions;

namespace IAlbumDB.Infrastructure.Services.Artist
{
    public class ArtistServices : IArtistService
    {
        protected readonly IArtistRepository _artistRepository;

        public ArtistServices(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        /// <summary>
        /// Gets All Artist with DTO artistReturnDto for a lightweight 
        /// </summary>
        /// <returns>IList<ArtistReturnDto>?</returns>
        public async Task<IList<ArtistBase>?> GetAllArtistAsync()
        {
            var artists = await _artistRepository.GetAllArtistAsync();
            var formattedArtists = artists?.Select(_ => _.ToBaseDto()).ToList();
            return formattedArtists;
        }

        /// <summary>
        /// Gets All An Artist details intersected with their albums by Id
        /// </summary>
        /// <returns type="IEnumerable<ArtistR>">IList<ArtistReturnDto>?</returns>
        public async Task<ArtistDetails?> GetArtistByIdAsync(Guid Id)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(Id) ?? throw new Exception($"Artist with Id:{Id} could not be found.");

            return artist.ToDetailedDto();
        }

        /// <summary>
        /// Creates a new artist for the database
        /// ### Done
        /// </summary>
        /// <param name="artist"></param>
        /// <returns type="Guid"></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Guid> CreateArtistAsync(ArtistCU artist)
        {
            // No duplicate artist / band names 
            if (await _artistRepository.FindArtistByNameAsync(artist.Name) != null)
            {
                throw new Exception($"Artist {artist.Name} already exists");
            }

            ArtistEntity newArtist = new ArtistEntity
            {
                Id = Guid.NewGuid(),
                Name = artist.Name,
                Musicians = artist.Type == ArtistType.Band ? artist.Musicians?.ToList(): new List<string> { artist.Name },
                Type = artist.Type,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _artistRepository.AddEntityAsync(newArtist);

            return newArtist.Id;
        }

        /// <summary>
        /// Update allows you to change the member values and other values to be added to the db
        /// ### Done
        /// </summary>
        public async Task UpdateArtistAsync(Guid Id, ArtistCU artist)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception($"Artist must have Id to update");
            }

            var updateArtist = await _artistRepository.GetByIdAsync(Id) ?? throw new Exception($"Artist with Id:{Id} could not be found.");

            updateArtist.Name = artist.Name;
            updateArtist.Musicians = artist.Musicians?.ToList();
            updateArtist.UpdatedAt = DateTime.UtcNow;

            await _artistRepository.UpdateEntityAsync(updateArtist);
        }

        /// <summary>
        /// Soft deletes an artist
        /// ### Done
        /// </summary>
        public async Task SoftDeleteArtistAsync(Guid Id)
        {
            var deletedArtist = await _artistRepository.GetByIdAsync(Id) ?? throw new Exception($"Artist with Id:{Id} could not be found.");

            deletedArtist.IsActive = false;
            deletedArtist.UpdatedAt = DateTime.UtcNow;

            await _artistRepository.UpdateEntityAsync(deletedArtist);
        }
    }
}
