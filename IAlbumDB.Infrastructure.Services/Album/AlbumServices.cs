using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Exceptions;
using IAlbumDB.Domain.Interfaces.Mapper;
using IAlbumDB.Domain.Interfaces.Repositories.Albums;
using IAlbumDB.Domain.Interfaces.Repositories.Artist;
using IAlbumDB.Domain.Interfaces.Services.Album;

namespace IAlbumDB.Infrastructure.Services.Album
{
    public class AlbumServices : IAlbumService
    {
        protected readonly IAlbumRepository _albumRepository;
        protected readonly IArtistRepository _artistRepository;
        private readonly IMapping<AlbumCreate, AlbumEntity> _albumCreateMapping;
        private readonly IMapping<AlbumDetails, AlbumEntity> _albumDetailsMapping;
        private readonly IMapping<AlbumReturn, AlbumEntity> _albumReturnMapping;

        public AlbumServices(
            IAlbumRepository albumRepository,
            IArtistRepository artistRepository,
            IMapping<AlbumCreate, AlbumEntity> albumCreateMapping,
            IMapping<AlbumDetails, AlbumEntity> albumDetailsMapping,
            IMapping<AlbumReturn, AlbumEntity> albumReturnMapping)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _albumCreateMapping = albumCreateMapping;
            _albumDetailsMapping = albumDetailsMapping;
            _albumReturnMapping = albumReturnMapping;
        }

        /// <summary>
        /// Gets All Albums intersected with Songs and Artist return DTO's
        /// </summary>
        /// <returns>IList<AlbumReturnDto></returns>
        public async Task<IList<AlbumReturn>?> GetAllAlbumsAsync()
        {
            var albums = await _albumRepository.GetAllAlbumsAsync() ?? [];
            var formattedAlbums = albums?.Select(_albumReturnMapping.Map).ToList();
            return formattedAlbums;
        }

        /// <summary>
        /// Gets All Albums intersected with Songs and Artist return DTO's filtered by the Artist's Id
        /// </summary>
        /// <returns>IList<AlbumReturnDto></returns>
        public async Task<IList<AlbumReturn>?> GetAllAlbumsByArtistAsync(Guid artistId)
        {
            var artistAlbums = await _albumRepository.GetAllByArtistAsync(artistId) ?? [];
            var formattedAlbums = artistAlbums?.Select(_albumReturnMapping.Map).ToList();
            return formattedAlbums;
        }

        /// <summary>
        /// Gets a single Albums detailed DTO by ID intersected with Song and Artists Detailed DTO 
        /// </summary>
        /// <returns>AlbumDetailsDto</returns>
        public async Task<AlbumDetails> GetAlbumByIdAsync(Guid id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);

            if (album == null)
            {
                throw new Exception($"Album with id:{id} could not be found");
            }

            return _albumDetailsMapping.Map(album);
        }

        /// <summary>
        /// Creates a new album after first checking the artist exist and that the artist does not have an album by the same name
        /// </summary>
        /// <returns>Guid</returns>
        public async Task<Guid> CreateAlbumAsync(AlbumCreate album)
        {
            if (!(album.Songs.Count > 0))
            {
                throw new MissingSongsException("Album cannot be created without songs attached");
            }

            var artist = await _artistRepository.GetByIdAsync(album.ArtistId);

            if (artist == null)
            {
                throw new Exception($"Artist with Id:{album.ArtistId} does not exist. Cannot create an album without an album.");
            }

            if (await _albumRepository.GetAlbumByNameAndArtistAsync(album.Name, album.ArtistId) != null)
            {
                throw new Exception($"Album with {album.Name} by artist {album.ArtistId} already exists");
            }

            AlbumEntity newAlbum = new AlbumEntity
            {
                Id = Guid.NewGuid(),
                Name = album.Name,
                Artist = artist,
                Year = album.Year,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            foreach (SongCreate Song in album.Songs)
            {
                newAlbum.Songs.Add(new SongEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Song.Name,
                    Track = Song.Track,
                    Length = Song.Length,
                    Lyrics = Song.Lyrics,
                    Genre = Song.Genre,
                    Artist = artist,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            await _albumRepository.AddEntityAsync(newAlbum);

            return newAlbum.Id;
        }

        /// <summary>
        /// Update and Delete do similar functions update allows for updates to an albums name and year while delete changes active flag to false
        /// </summary>
        public async Task UpdateAlbumAsync(AlbumUpdate data)
        {
            var updateAlbum = await _albumRepository.GetByIdAsync(data.Id);

            if (updateAlbum == null)
            {
                throw new Exception($"Album with id:{data.Id} could not be found");
            }

            updateAlbum.Name = data.Name;
            updateAlbum.Year = data.Year;
            updateAlbum.UpdatedAt = DateTime.UtcNow;

            await _albumRepository.UpdateEntityAsync(updateAlbum);
        }

        public async Task DeleteAlbumAsync(Guid id)
        {
            var deleteAlbum = await _albumRepository.GetByIdAsync(id);

            if (deleteAlbum == null)
            {
                throw new Exception($"Album with id:{id} could not be found");
            }

            deleteAlbum.IsActive = false;
            deleteAlbum.UpdatedAt = DateTime.UtcNow;

            await _albumRepository.UpdateEntityAsync(deleteAlbum);
        }
    }
}
