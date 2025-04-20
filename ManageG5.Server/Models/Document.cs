namespace ManageG5.Server.Models
{
    public class Document
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
