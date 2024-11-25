namespace StreamingAPI.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  
        public string Description { get; set; } = string.Empty;  
        public List<Content> Contents { get; set; } = new List<Content>();  

        public Playlist() { }  
    }
}

