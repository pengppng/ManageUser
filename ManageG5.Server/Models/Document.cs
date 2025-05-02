namespace ManageG5.Server.Models
{
    public class Document
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
