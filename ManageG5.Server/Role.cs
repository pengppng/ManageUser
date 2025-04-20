using System.Security;

namespace ManageG5.Server
{
    public class Role
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<Permission> Permissions { get; set; }
    }
}