using Microsoft.AspNetCore.Mvc;
using StreamingAPI.Models;
using StreamingAPI.Repositories;

namespace StreamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistRepository _repository;

        public PlaylistController(PlaylistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Playlist>>> GetAllPlaylists()
        {
            return await _repository.GetAllPlaylistsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylistById(int id)
        {
            var playlist = await _repository.GetPlaylistByIdAsync(id);
            if (playlist == null) return NotFound();
            return playlist;
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> AddPlaylist(Playlist playlist)
        {
            var createdPlaylist = await _repository.AddPlaylistAsync(playlist);
            return CreatedAtAction(nameof(GetPlaylistById), new { id = createdPlaylist.Id }, createdPlaylist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlaylist(int id, Playlist playlist)
        {
            if (id != playlist.Id) return BadRequest();
            var result = await _repository.UpdatePlaylistAsync(playlist);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var result = await _repository.DeletePlaylistAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
