using IAlbumDB.Domain.DTOs.CreateUpdate.Albums;
using IAlbumDB.Domain.DTOs.Return.Albums;
using IAlbumDB.Domain.Interfaces.Services.Album;
using Microsoft.AspNetCore.Mvc;

namespace IAlbumDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumServices;

        public AlbumController(IAlbumService albumServices)
        {
            _albumServices = albumServices;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AlbumBase>>> GetAllAlbums([FromQuery] Guid? artistId)
        {
            try
            {
                if (artistId != null)
                {
                    return Ok(await _albumServices.GetAllAlbumsByArtistAsync((Guid)artistId));
                }
                else
                {
                    return Ok(await _albumServices.GetAllAlbumsAsync());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{albumId}")]
        public async Task<ActionResult<AlbumDetails>> GetAlbumById(Guid albumId)
        {
            try
            {
                var album = await _albumServices.GetAlbumByIdAsync(albumId);
                return Ok(album);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAlbum([FromBody] AlbumCU newAlbum)
        {
            try
            {
                var albumId = await _albumServices.CreateAlbumAsync(newAlbum);
                return Ok(albumId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{albumId}")]
        public async Task<ActionResult> UpdateAlbum(Guid albumId, [FromBody] AlbumCU updateAlbum)
        {
            try
            {
                await _albumServices.UpdateAlbumAsync(albumId, updateAlbum);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{albumId}")]
        public async Task<ActionResult> DeleteAlbum(Guid albumId)
        {
            try
            {
                await _albumServices.DeleteAlbumAsync(albumId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
