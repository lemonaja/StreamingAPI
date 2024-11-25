namespace StreamingAPI.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Type { get; set; } // Ex: Vídeo, Música, Podcast
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
