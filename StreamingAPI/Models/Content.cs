namespace StreamingAPI.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;  
        public string Url { get; set; } = string.Empty;  
        public string Type { get; set; } = string.Empty;  
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; } = new Playlist();  
    }
}


