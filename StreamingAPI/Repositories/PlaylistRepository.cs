using StreamingAPI.Models;
using StreamingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace StreamingAPI.Repositories
{
    public class PlaylistRepository
    {
        private readonly AppDbContext _context;

        public PlaylistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Playlist>> GetAllPlaylistsAsync()
        {
            return await _context.Playlists.Include(p => p.Contents).ToListAsync();
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id)
        {
            return await _context.Playlists.Include(p => p.Contents).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Playlist> AddPlaylistAsync(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<bool> UpdatePlaylistAsync(Playlist playlist)
        {
            _context.Entry(playlist).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlaylistAsync(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null) return false;

            _context.Playlists.Remove(playlist);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
