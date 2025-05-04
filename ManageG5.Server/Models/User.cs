using System.Data;

namespace ManageG5.Server.Models
{
    public class User
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Username: {Username}, Email: {Email}, PhoneNumber: {PhoneNumber}, RoleId: {RoleId}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
        }
    }
}
