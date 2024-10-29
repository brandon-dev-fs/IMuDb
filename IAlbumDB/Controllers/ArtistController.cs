using IAlbumDB.Domain.DTOs.Artist;
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
        public async Task<ActionResult<IList<ArtistReturnDto>>> GetArtists()
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
        public async Task<ActionResult<ArtistDetailsDto>> GetArtist(Guid artistId)
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
        public async Task<ActionResult<Guid>> CreateArtist([FromBody] ArtistCreateDto newArtist)
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

        [HttpPut]
        public async Task<ActionResult> UpdateArtist([FromBody] ArtistUpdateDto updateArtist)
        {
            try
            {
                await _artistServices.UpdateArtistAsync(updateArtist);
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
                await _artistServices.DeleteArtistAsync(artistId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
