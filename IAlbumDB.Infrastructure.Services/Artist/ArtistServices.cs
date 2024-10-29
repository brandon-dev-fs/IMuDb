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
        private readonly IMapping<ArtistDetailsDto, ArtistEntity> _artistDetailedMapping;
        private readonly IMapping<ArtistReturnDto, ArtistEntity> _artistReturnMapping;
        private readonly IMapping<ArtistReturnDto, ArtistEntity> _artistCreateMapping;

        public ArtistServices(IArtistRepository artistRepository,
            IMapping<ArtistDetailsDto, ArtistEntity> artistDetailedMapping,
            IMapping<ArtistReturnDto, ArtistEntity> artistReturnMapping,
            IMapping<ArtistReturnDto, ArtistEntity> artistCreateMapping)
        {
            _artistRepository = artistRepository;
            _artistDetailedMapping = artistDetailedMapping;
            _artistReturnMapping = artistReturnMapping;
            _artistCreateMapping = artistCreateMapping;
        }

        /// <summary>
        /// Gets All Artist with DTO artistReturnDto for a lightweight 
        /// </summary>
        /// <returns>IList<ArtistReturnDto>?</returns>
        public async Task<IList<ArtistReturnDto>?> GetAllArtistAsync()
        {
            var artists = await _artistRepository.GetAllArtistAsync();
            var formattedArtists = artists?.Select(_artistReturnMapping.MapToDto).ToList();
            return formattedArtists;
        }

        /// <summary>
        /// Gets All An Artist details intersected with their albums by Id
        /// </summary>
        /// <returns>IList<ArtistReturnDto>?</returns>
        public async Task<ArtistDetailsDto?> GetArtistByIdAsync(Guid id)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(id);

            if (artist == null)
            {
                throw new Exception($"Artist with Id:{id} could not be found.");
            }

            return _artistDetailedMapping.MapToDto(artist);
        }

        public async Task<Guid> CreateArtistAsync(ArtistCreateDto artist)
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
        /// Update and Delete do similar functions update allows for updates to an artist or bands members and year while delete changes active flag to false
        /// </summary>
        public async Task UpdateArtistAsync(ArtistUpdateDto artist)
        {
            var updateArtist = await _artistRepository.GetByIdAsync(artist.Id);

            if (updateArtist == null)
            {
                throw new Exception($"Artist with Id:{artist.Id} could not be found.");
            }

            // blanket update limited cost no need to check for differences just set and update in db
            updateArtist.Members = artist.Members?.ToList();
            updateArtist.UpdatedAt = DateTime.UtcNow;

            await _artistRepository.UpdateEntityAsync(updateArtist);
        }

        public async Task DeleteArtistAsync(Guid id)
        {
            var deleteArtist = await _artistRepository.GetByIdAsync(id);

            if (deleteArtist == null)
            {
                throw new Exception($"Artist with Id:{id} could not be found.");
            }

            deleteArtist.IsActive = false;
            deleteArtist.UpdatedAt = DateTime.UtcNow;

            await _artistRepository.UpdateEntityAsync(deleteArtist);
        }
    }
}
