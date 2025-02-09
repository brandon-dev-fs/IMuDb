using IAlbumDB.Domain.DTOs.CreateUpdate.Songs;
using IAlbumDB.Domain.DTOs.Return.Songs;
using IAlbumDB.Domain.Interfaces.Services.Song;
using Microsoft.AspNetCore.Mvc;

namespace IAlbumDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songServices;

        public SongController(ISongService songServices)
        {
            _songServices = songServices;
        }

        /// <summary>
        /// Gets the details for a specific song based on song Id
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        [HttpGet("{songId}")]
        public async Task<ActionResult<SongDetails>> GetSongDetails(Guid songId)
        {
            try
            {
                var song = await _songServices.GetSongByIdAsync(songId);
                return Ok(song);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Allows update to song entity for lyrics, genere, other non key fields
        /// </summary>
        /// <param name="updateSong"></param>
        /// <returns></returns>
        [HttpPut("{songId}")]
        public async Task<ActionResult> UpdateSong(Guid songId, [FromBody] SongCU updateSong)
        {
            try
            {
                await _songServices.UpdateSongAsync(songId, updateSong);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
