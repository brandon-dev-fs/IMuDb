using IAlbumDB.Domain.DTOs.Songs;
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

        [HttpGet]
        public async Task<ActionResult<IList<SongReturnDto>?>> GetSongsAsync([FromQuery] Guid? albumId)
        {
            try
            {
                if (albumId != null)
                {
                    var songs = await _songServices.GetAllSongsByAlbumAsync((Guid)albumId);
                    return Ok(songs);
                }
                else
                {
                    var songs = await _songServices.GetAllSongsAsync();
                    return Ok(songs);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{songId}")]
        public async Task<ActionResult<SongDetailsDto>> GetSongDetails(Guid songId)
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

        // Song creation temporarily only handled through album creation
        //[HttpPost]
        //public async Task<ActionResult<SongDetailsDto>> CreateSong([FromBody] SongDto newSong)
        //{
        //    try
        //    {
        //        var songId = await _songServices.CreateSongAsync(newSong);
        //        return Ok(songId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPut]
        public async Task<ActionResult> UpdateSong([FromBody] SongUpdateDto updateSong)
        {
            try
            {
                await _songServices.UpdateSongAsync(updateSong);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Songs can not be deleted by endpoint only by deletion of an album
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<SongDetailsDto>> DeleteSong(Guid id)
        //{
        //    try
        //    {
        //        await _songServices.DeleteSongAsync(id);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
