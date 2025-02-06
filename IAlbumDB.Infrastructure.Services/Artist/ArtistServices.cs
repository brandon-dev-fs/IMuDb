using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Interfaces.Mapper;
using IAlbumDB.Domain.Interfaces.Repositories.Artist;
using IAlbumDB.Domain.Interfaces.Services.Artist;

namespace IAlbumDB.Infrastructure.Services.Artist
{
    public class ArtistServices : IArtistService
    {
        protected readonly IArtistRepository _artistRepository;
        private readonly IMapping<ArtistDetails, ArtistEntity> _artistDetailedMapping;
        private readonly IMapping<ArtistReturn, ArtistEntity> _artistReturnMapping;

        public ArtistServices(IArtistRepository artistRepository,
            IMapping<ArtistDetails, ArtistEntity> artistDetailedMapping,
            IMapping<ArtistReturn, ArtistEntity> artistReturnMapping,
            IMapping<ArtistReturn, ArtistEntity> artistCreateMapping)
        {
            _artistRepository = artistRepository;
            _artistDetailedMapping = artistDetailedMapping;
            _artistReturnMapping = artistReturnMapping;
        }

        /// <summary>
        /// Gets All Artist with DTO artistReturnDto for a lightweight 
        /// </summary>
        /// <returns>IList<ArtistReturnDto>?</returns>
        public async Task<IList<ArtistReturn>?> GetAllArtistAsync()
        {
            var artists = await _artistRepository.GetAllArtistAsync();
            var formattedArtists = artists?.Select(_artistReturnMapping.Map).ToList();
            return formattedArtists;
        }

        /// <summary>
        /// Gets All An Artist details intersected with their albums by Id
        /// </summary>
        /// <returns type="IEnumerable<ArtistR>">IList<ArtistReturnDto>?</returns>
        public async Task<ArtistDetails?> GetArtistByIdAsync(Guid id)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(id) ?? throw new Exception($"Artist with Id:{id} could not be found.");

            return _artistDetailedMapping.Map(artist);
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
                Members = artist.Members?.ToList(),
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
        public async Task UpdateArtistAsync(ArtistCU artist)
        {
            if (artist.Id == Guid.Empty || artist.Id is null)
            {
                throw new Exception($"Artist must have Id to update");
            }

            var updateArtist = await _artistRepository.GetByIdAsync((Guid)artist.Id) ?? throw new Exception($"Artist with Id:{artist.Id} could not be found.");

            updateArtist.Name = artist.Name;
            updateArtist.Members = artist.Members?.ToList();
            updateArtist.UpdatedAt = DateTime.UtcNow;

            await _artistRepository.UpdateEntityAsync(updateArtist);
        }

        /// <summary>
        /// Soft deletes an artist
        /// ### Done
        /// </summary>
        public async Task SoftDeleteArtistAsync(Guid id)
        {
            var deleteArtist = await _artistRepository.GetByIdAsync(id) ?? throw new Exception($"Artist with Id:{id} could not be found.");

            deleteArtist.IsActive = false;
            deleteArtist.UpdatedAt = DateTime.UtcNow;

            await _artistRepository.UpdateEntityAsync(deleteArtist);
        }
    }
}
