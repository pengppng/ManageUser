using System.Security;

namespace ManageG5.Server.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}