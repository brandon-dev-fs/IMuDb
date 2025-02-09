﻿using IAlbumDB.Domain.DTOs.Return.Albums;
using IAlbumDB.Domain.DTOs.Return.Artists;
using IAlbumDB.Domain.DTOs.Return.Songs;
using IAlbumDB.Domain.Entities.Songs;

namespace IAlbumDB.Infrastructure.Extensions
{
    public static class MappingExtensions
    {
        public static SongDetails ToDto(this SongEntity song)
        {
            return new SongDetails
            {
                Id = song.Id,
                Name = song.Name,
                Length = song.Length,
                Genre = song.Genre ?? string.Empty,
                Lyrics = song.Lyrics ?? string.Empty,
                Album = new AlbumBase
                {
                    Id = song.Album?.Id,
                    Name = song.Album.Name,
                    Artist = new ArtistBase
                    {
                        Id = song.Artist?.Id,
                        Name = song.Artist.Name,
                        Members = song.Artist.Members ?? new List<string>()
                    },
                },
                UpdatedAt = song.UpdatedAt
            };
        }
    }
}
