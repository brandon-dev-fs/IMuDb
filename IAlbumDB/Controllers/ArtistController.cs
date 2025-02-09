using IAlbumDB.Domain.DTOs.CreateUpdate.Artists;
using IAlbumDB.Domain.DTOs.Return.Artists;
using IAlbumDB.Domain.Interfaces.Services.Artist;
using Microsoft.AspNetCore.Mvc;

namespace IAlbumDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistServices;

        public ArtistController(IArtistService artistServices)
        {
            _artistServices = artistServices;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ArtistBase>>> GetArtists()
        {
            try
            {
                var artists = await _artistServices.GetAllArtistAsync();
                return Ok(artists);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{artistId}")]
        public async Task<ActionResult<ArtistDetails>> GetArtist(Guid artistId)
        {
            try
            {
                var artist = await _artistServices.GetArtistByIdAsync(artistId);
                return Ok(artist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateArtist([FromBody] ArtistCU newArtist)
        {
            try
            {
                var artistId = await _artistServices.CreateArtistAsync(newArtist);
                return Ok(artistId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{artistId}")]
        public async Task<ActionResult> UpdateArtist(Guid artistId, [FromBody] ArtistCU updateArtist)
        {
            try
            {
                await _artistServices.UpdateArtistAsync(artistId, updateArtist);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{artistId}")]
        public async Task<ActionResult> DeleteArtist(Guid artistId)
        {
            try
            {
                await _artistServices.SoftDeleteArtistAsync(artistId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
